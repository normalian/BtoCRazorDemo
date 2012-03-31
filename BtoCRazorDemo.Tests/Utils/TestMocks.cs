using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Linq;
using BtoCRazorDemo;
using BtoCRazorDemo.Controllers;
using BtoCRazorDemo.Tests.Models;

namespace BtoCRazorDemo.Tests.Utils
{
    class MockHttpSessionState : HttpSessionStateBase
    {
        public MockHttpSessionState()
        {
            Values = new Dictionary<string, object>();
        }

        public IDictionary<string, object> Values { get; private set; }

        public override object this[string key]
        {
            get { return Values[key]; }
            set { Values[key] = value; }
        }

        public override void Abandon()
        {
            Values.Clear();
        }
    }

    public class MockHttpContext : HttpContextBase
    {
        private IPrincipal _user;
        private HttpSessionStateBase _session;

        public override IPrincipal User
        {
            get
            {
                if (_user == null)
                {
                    _user = new MockPrincipal();
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        public override HttpSessionStateBase Session
        {
            get
            {
                if (_session == null)
                {
                    _session = new MockHttpSessionState();
                }
                return _session;
            }
        }
    }


    public class MockIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get
            {
                return "MockAuthentication";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "someUser";
            }
        }
    }

    public class MockPrincipal : IPrincipal
    {
        IIdentity _identity;

        public IIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    _identity = new MockIdentity();
                }
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return false;
        }
    }

}
