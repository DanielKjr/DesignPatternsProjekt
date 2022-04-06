using System.Collections.Generic;

namespace DesignPatternsProjekt
{

    public class CollisionEvent
    {
        private List<IListner> listners = new List<IListner> ();
        public GameObject Other { get; private set; }

        public void Attach(IListner listner)
        {
            listners.Add(listner);
        }

        public void OnCollision(GameObject other)
        {
            Other = other;
            Notify(Other);
        
        }

        public void Notify(GameObject other)
        {
            foreach (IListner listener in listners)
            {
                listener.Notify(this);
            }
        }
    }

    public interface IListner
    {
        void Notify(CollisionEvent collisionEvent);
    }
}
