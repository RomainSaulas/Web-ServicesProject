using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class EntityObject
    {
        private int id;

        public EntityObject(int id)
        {
            this.id = id;
        }
        
        public int Id
        {
            get{
                return id;
            }
            set
            {
                id=value;
            }
       }


        public override bool Equals(object obj)
        {
 	         return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }       
}
