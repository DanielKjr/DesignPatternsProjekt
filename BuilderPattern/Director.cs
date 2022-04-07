namespace DesignPatternsProjekt
{

    public class Director
    {
        private PlayerBuilder builder;
        private AsteroidBuilder aBuilder;

        public Director(PlayerBuilder builder)
        {
            this.builder = builder;
        }

        public Director(AsteroidBuilder builder)
        {
            aBuilder = builder;
        }

        /// <summary>
        /// returns a gameobject of the specified builder type
        /// </summary>
        /// <returns></returns>
        public GameObject Construct()
        {
            if (builder != null)
            {
                builder.BuildGameObject();
                return builder.GetResult();
            }
            else
            {
                aBuilder.BuildGameObject();
                return aBuilder.GetResult();
            }
           
        }
    }

}
