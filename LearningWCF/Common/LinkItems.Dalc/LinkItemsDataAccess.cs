// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Transactions;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using ContentTypes;

namespace LinkItems.Dalc
{
    /// <summary>
    /// Data access component for the LinkItems tables. 
    /// It uses a SqlDataReader instead of typed datasets for improved
    /// performance. Though not required, this type is intended to 
    /// be loaded and cached for repeat use. The type is thread safe.
    /// </summary>
    [Synchronization]
    public class LinkItemsDataAccess : IDisposable
    {
        private SqlConnection m_connection;
        
        private SqlCommand m_cmdLinkItemsSelect;
        private SqlCommand m_cmdLinkItemsSelectById;
        private SqlCommand m_cmdLinkItemsInsert;
        
        private SqlCommand m_cmdCategoriesSelect;
        private SqlCommand m_cmdCategoriesSelectByTitle;
        private SqlCommand m_cmdCategoriesInsert;

        private SqlCommand m_cmdLinkItemCategoryInsert;
        
        private SqlCommand m_cmdLinkItemTypesInsert;

        private string m_connectionString;

        public LinkItemsDataAccess(string connectionString)
        {
            // grab the connection string
            if (connectionString==null)
                connectionString = ConfigurationManager.ConnectionStrings["LinkItemsConnectionString"].ConnectionString;
            m_connectionString = connectionString;
            m_connection = new SqlConnection(m_connectionString);

            // insert LinkItemTypes
            m_cmdLinkItemTypesInsert = new SqlCommand("procLinkItemTypesInsert");
            m_cmdLinkItemTypesInsert.CommandType = CommandType.StoredProcedure;
            m_cmdLinkItemTypesInsert.Connection = m_connection;
            SqlParameter param = m_cmdLinkItemTypesInsert.Parameters.AddWithValue("@id", null);
            param.SqlDbType=SqlDbType.Int;
            
            m_cmdLinkItemTypesInsert.Parameters.AddWithValue("@name", null);
            m_cmdLinkItemTypesInsert.Parameters.AddWithValue("@description", null);

            // save LinkItems
            m_cmdLinkItemsInsert = new SqlCommand("procLinkItemsInsert");
            m_cmdLinkItemsInsert.CommandType = CommandType.StoredProcedure;
            m_cmdLinkItemsInsert.Connection = m_connection;
            

            SqlParameter idParam = this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@id", null);
            idParam.Direction = ParameterDirection.Output;

            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@title", null);
            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@description", null);
            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@url", null);
            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@linkitem_date", null);
            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@linkitem_dateend", null);
            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@linkitem_type", null);
            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@date_created", null);
            this.m_cmdLinkItemsInsert.Parameters.AddWithValue("@date_modified", null);

            // save Categories
            m_cmdCategoriesInsert = new SqlCommand("procCategoriesInsert");
            m_cmdCategoriesInsert.CommandType = CommandType.StoredProcedure;
            m_cmdCategoriesInsert.Connection = m_connection;

            idParam = this.m_cmdCategoriesInsert.Parameters.AddWithValue("@id", null);
            idParam.Direction = ParameterDirection.Output;
            this.m_cmdCategoriesInsert.Parameters.AddWithValue("@title", null);
            this.m_cmdCategoriesInsert.Parameters.AddWithValue("@description", null);
            this.m_cmdCategoriesInsert.Parameters.AddWithValue("@date_created", null);
            this.m_cmdCategoriesInsert.Parameters.AddWithValue("@date_modified", null);

            // save LinkItem_Category
            m_cmdLinkItemCategoryInsert = new SqlCommand("procLinkItem_CategoryInsert");
            m_cmdLinkItemCategoryInsert.CommandType = CommandType.StoredProcedure;
            m_cmdLinkItemCategoryInsert.Connection = m_connection;

            m_cmdLinkItemCategoryInsert.Parameters.AddWithValue("@linkitem_id", null);
            m_cmdLinkItemCategoryInsert.Parameters.AddWithValue("@category_id", null);

            // get Categories
            m_cmdCategoriesSelect = new SqlCommand("procCategoriesSelect");
            m_cmdCategoriesSelect.CommandType = CommandType.StoredProcedure;
            m_cmdCategoriesSelect.Connection = m_connection;

            // get Category by Id
            m_cmdCategoriesSelectByTitle = new SqlCommand("SELECT * FROM Categories WHERE (title=@title)");
            m_cmdCategoriesSelectByTitle.Parameters.AddWithValue("@title", null);
            m_cmdCategoriesSelectByTitle.Connection = m_connection;


            // get LinkItems
            m_cmdLinkItemsSelect = new SqlCommand("procLinkItemsSelect");
            m_cmdLinkItemsSelect.CommandType = CommandType.StoredProcedure;
            m_cmdLinkItemsSelect.Connection = m_connection;

            // get all LinkItems by Id
            m_cmdLinkItemsSelectById = new SqlCommand("SELECT * FROM LinkItems WHERE (id=@id)");
            m_cmdLinkItemsSelectById.Parameters.AddWithValue("@id", null);
            m_cmdLinkItemsSelectById.Connection = m_connection;

        }

        public LinkItemsDataAccess(): this(null)
        {
        }
        public virtual void InsertLinkItemType(int id, string name, string description)        {
            using (TransactionScope scope = new TransactionScope())
            {

                this.m_cmdLinkItemTypesInsert.Parameters["@id"].Value = id;
                this.m_cmdLinkItemTypesInsert.Parameters["@name"].Value = name;
                this.m_cmdLinkItemTypesInsert.Parameters["@description"].Value = description;

                using (this.m_connection)
                {
                    this.m_connection.Open();
                    m_cmdLinkItemsInsert.ExecuteNonQuery();
                }

                scope.Complete();
            }
        }

        /// <summary>
        /// Save a new LinkItem and associate it with the specified category.
        /// </summary>
        public virtual void InsertLinkItem(string title, string description, string url, LinkItemTypes linkitem_type, DateTime linkitem_date, DateTime? linkitem_dateend, string category)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                DateTime dt = DateTime.Now;
                
                this.m_cmdLinkItemsInsert.Parameters["@id"].Value = -1;
                this.m_cmdLinkItemsInsert.Parameters["@title"].Value = title;
                this.m_cmdLinkItemsInsert.Parameters["@description"].Value = description;
                this.m_cmdLinkItemsInsert.Parameters["@url"].Value = url;
                this.m_cmdLinkItemsInsert.Parameters["@linkitem_date"].Value = linkitem_date;

                if (linkitem_dateend==null)
                    this.m_cmdLinkItemsInsert.Parameters["@linkitem_dateend"].Value = DBNull.Value; 
                else
                    this.m_cmdLinkItemsInsert.Parameters["@linkitem_dateend"].Value = linkitem_dateend; 

                this.m_cmdLinkItemsInsert.Parameters["@linkitem_type"].Value = linkitem_type;
                this.m_cmdLinkItemsInsert.Parameters["@date_created"].Value= dt;
                this.m_cmdLinkItemsInsert.Parameters["@date_modified"].Value = dt;

                using (this.m_connection)
                {
                    this.m_connection.Open();
                    int linkItemId = -1;
                    int catId = -1;

                    // save the LinkItem record
                    using (SqlDataReader linkItemsReader = this.m_cmdLinkItemsInsert.ExecuteReader())
                    {
                        linkItemId = Convert.ToInt32(m_cmdLinkItemsInsert.Parameters["@id"].Value);
                
                    }

           
                    // see if the category already exists
                    m_cmdCategoriesSelectByTitle.Parameters["@title"].Value = category;
                    using(SqlDataReader categoryReader = m_cmdCategoriesSelectByTitle.ExecuteReader())
                    {

                        // create a category if it doesn't exist
                        if (categoryReader!=null && categoryReader.HasRows == true)
                        {
                            categoryReader.Read();
                            catId = categoryReader.GetInt32(categoryReader.GetOrdinal("id"));
                        }

                    }

                    // create a category if it doesn't exist
                    if (catId==-1)
                    {
                        dt = DateTime.Now;

                        m_cmdCategoriesInsert.Parameters["@id"].Value = -1;
                        m_cmdCategoriesInsert.Parameters["@title"].Value = category;
                        m_cmdCategoriesInsert.Parameters["@description"].Value = DBNull.Value;
                        m_cmdCategoriesInsert.Parameters["@date_created"].Value= dt;
                        m_cmdCategoriesInsert.Parameters["@date_modified"].Value = dt;

                        m_cmdCategoriesInsert.ExecuteNonQuery();
                        catId = Convert.ToInt32(m_cmdCategoriesInsert.Parameters["@id"].Value);
   
                    }       

                    // create relationship with category
                    m_cmdLinkItemCategoryInsert.Parameters["@linkitem_id"].Value = linkItemId;
                    m_cmdLinkItemCategoryInsert.Parameters["@category_id"].Value = catId;
                    m_cmdLinkItemCategoryInsert.ExecuteNonQuery();
                    
                }
                // complete the transaction
                scope.Complete();
            }
           
        }

        public virtual T GetLinkItem<T>(int id) where T : LinkItem, new()
        {
            T item = null;
            using (m_connection)
            {
                m_connection.Open();

                m_cmdLinkItemsSelectById.Parameters["@id"].Value = id;
                using (SqlDataReader reader = m_cmdLinkItemsSelectById.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item = new T();
                        item.Id=id;
                        item.Title=reader.GetString(reader.GetOrdinal("title"));
                        item.Description=reader.GetString(reader.GetOrdinal("description"));
                        item.Url=reader.GetString(reader.GetOrdinal("url"));
                        item.DateStart=reader.GetDateTime(reader.GetOrdinal("linkitem_date"));
                        item.DateEnd = reader.GetValue(reader.GetOrdinal("linkitem_dateend")) as DateTime?;
                        
                        
                    }
                }
            }

            return item;

        }

        public virtual List<T> GetLinkItems<T>() where T : LinkItem, new()
        {
            List<T> linkItems = new List<T>();
            using (m_connection)
            {
                m_connection.Open();
                using (SqlDataReader reader = m_cmdLinkItemsSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T item = new T();
                        item.Id=reader.GetInt32(reader.GetOrdinal("id"));
                        item.Title=reader.GetString(reader.GetOrdinal("title"));
                        item.Description=reader.GetString(reader.GetOrdinal("description"));
                        item.Url=reader.GetString(reader.GetOrdinal("url"));
                        item.DateStart=reader.GetDateTime(reader.GetOrdinal("linkitem_date"));
                        item.DateEnd = reader.GetValue(reader.GetOrdinal("linkitem_dateend")) as DateTime?;
                        
                        linkItems.Add(item);
                    }
                }
            }

            return linkItems;

        }

        public virtual List<string> GetCategories() 
        {
            List<string> categories = new List<string>();
            using (m_connection)
            {
                m_connection.Open();
                using (SqlDataReader reader = m_cmdCategoriesSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(reader.GetString(reader.GetOrdinal("title")));
                    }
                }
            }

            return categories;

        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                // TODO: add in idisposable pattern, check what we're cleaning up here
                this.m_cmdCategoriesSelect.Dispose();
                this.m_cmdLinkItemsSelectById.Dispose();
                this.m_cmdLinkItemsInsert.Dispose();
                this.m_connection.Dispose();
            }
            catch { }
        }

        #endregion
    }
   

}
