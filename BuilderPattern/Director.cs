namespace DesignPatternsProjekt
{

    public class Director
    {
        private PlayerBuilder builder;

        public Director(PlayerBuilder builder)
        {
            this.builder = builder;
        }

        /// <summary>
        /// returns a gameobject of the specified builder type
        /// </summary>
        /// <returns></returns>
        public GameObject Construct()
        {
            builder.BuildGameObject();
            return builder.GetResult();
        }
    }

}
