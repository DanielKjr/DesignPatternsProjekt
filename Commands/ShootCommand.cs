namespace DesignPatternsProjekt
{
    
        public class ShootCommand : ICommand
        {
            public void Execute(Player player)
            {
                player.Shoot();
            }
        }
    
}
