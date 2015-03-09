using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCA.Communication
{
    /// <summary>
    /// Simple request will be sent to send one value
    /// </summary>
    public class SimpleRequest
    {
        public String RequestString;
    }

    /// <summary>
    /// When a single entity is needs to be passed this can be used
    /// </summary>
    public class EntityRequest
    {
        public String ID;
        public int ChangedBy;
    }

    /// <summary>
    /// When a pair of entity needs to be passed this will be used.
    /// </summary>
    public class EntityPairRequest
    {
        public String EntityID1;
        public String EntityID2;
    }
}
