using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonManager.DTO;
using CommonManager.BusinessObjects;

namespace CommonManager.Entity
{
    /// <summary>
    /// Entity class for state. This will manage create / modify entities
    /// </summary>
    public class State
    {
        private int _ID;
        private int _CountryID;
        private Country _Country;
        private String _StateName;
        private int _RegionID;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public int CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }
        public Country Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }


        public String StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }
        public int RegionID
        {
            get
            {
                return _RegionID;
            }
            set
            {
                _RegionID = value;
            }
        }
        /// <summary>
        /// Update the entity based on the DTO object
        /// </summary>
        /// <param name="State">DTO object</param>
        public State(Common_State State)
        {
            Update(State);
        }

        /// <summary>
        /// Construct the object based on DTO
        /// </summary>
        /// <param name="State">DTO object</param>
        private void Update(Common_State State)
        {
            _ID = State.ID;
            _CountryID = State.CountryID;
            _Country = new Country(State.CountryID); 
            _StateName = State.StateName;
            _RegionID=State.RegionID;
        }

        /// <summary>
        /// Construct the object by the ID.
        /// </summary>
        /// <param name="ID">State ID</param>
        public State(int ID)
        {
            Common_State State = new Common_StateBusinessObject().GetCommon_State(ID);
            if(State!=null)
                Update(State);
        }

        /// <summary>
        /// This will be used when the entity passed directly to any method
        /// </summary>
        /// <returns>Name Of the The State</returns>
        public override string ToString()
        {
            return _StateName;
        }

        /// <summary>
        /// Get all the states
        /// </summary>
        /// <returns>Arry Of state objects</returns>
        public static State[] GetAllStates()
        {
            Common_State[] StateDT = new Common_StateBusinessObject().GetCommon_State();

            State[] State = new State[StateDT.Length];

            for (int i = 0; i < State.Length; i++)
            {
                State[i] = new State(StateDT[i]);
            }

            return State;
        }

        /// <summary>
        /// Returns the states which comes under that country
        /// </summary>
        /// <param name="CountryID">Contry ID</param>
        /// <returns>Array of state object</returns>
        public static State[] GetStates(int CountryID)
        {
            Common_State[] StateDT = new Common_StateBusinessObject().GetStates(CountryID);

            State[] State = new State[StateDT.Length];

            for (int i = 0; i < State.Length; i++)
            {
                State[i] = new State(StateDT[i]);
            }

            return State;
        }
        public static State[] GetStatesForRegion(int RegionID)
        {
            Common_State[] StateDT = new Common_StateBusinessObject().GetStatesDetails(RegionID);

            State[] State = new State[StateDT.Length];

            for (int i = 0; i < State.Length; i++)
            {
                State[i] = new State(StateDT[i]);
            }

            return State;
        }
    }
}
