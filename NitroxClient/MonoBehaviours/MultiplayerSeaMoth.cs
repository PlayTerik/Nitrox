﻿namespace NitroxClient.MonoBehaviours
{
    class MultiplayerSeaMoth : MultiplayerVehicleControl<Vehicle>
    {
        private bool lastThrottle = false;
        private SeaMoth seamoth;

        protected override void Awake()
        {
            steeringControl = seamoth = GetComponent<SeaMoth>();
            base.Awake();
        }

        internal override void Exit()
        {
            seamoth.bubbles.Stop();
            base.Exit();
        }

        internal override void SetThrottle(bool isOn)
        {
            if (isOn != lastThrottle)
            {
                if (isOn)
                {
                    seamoth.bubbles.Play();
                }
                else
                {
                    seamoth.bubbles.Stop();
                }

                lastThrottle = isOn;
            }
        }
    }
}
