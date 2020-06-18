namespace ExitGames.Client.Photon
{
	public struct SendOptions
	{
		public bool Reliability
		{
			get
			{
				return DeliveryMode == DeliveryMode.Reliable;
			}
			set
			{
				DeliveryMode = (value ? DeliveryMode.Reliable : DeliveryMode.Unreliable);
			}
		}

		public static readonly SendOptions SendReliable;

		public static readonly SendOptions SendUnreliable;

		public DeliveryMode DeliveryMode;

		public bool Encrypt;

		public byte Channel;
	}
}
