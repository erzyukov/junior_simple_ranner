namespace Game
{
    public class RepairKit : PowerUp
    {
		public override Type PowerUpType => Type.RepairKit;

		protected override void Apply(Player player) =>
			player.ApplyRepair();
	}
}
