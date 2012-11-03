//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
// Original sample from Martin Gudgin of Microsoft
// Modifed by Michele Leroux Bustamante, April 2007

using System;

using System.ServiceModel;
using System.ServiceModel.Channels;

using Gudge.Samples.Security.RSTRSTR;

namespace TokenIssuer
{
    [ServiceContract]
    interface IWSTrust
    {
        [OperationContract(Action = Constants.Trust.Actions.Issue, ReplyAction = Constants.Trust.Actions.IssueReply)]
        Message Issue(Message request);
    }
}
