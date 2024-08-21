using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class GameObjectComponent : Entity, IAwake, IDestroy
    {
        private GameObject gameObject;

        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }
            set
            {
                this.gameObject = value;

                if (value != null)
                {
                    this.Transform = value.transform;
                    this.Head = value.transform.Find("Head");
                    this.Neck = value.transform.Find("Neck");
                    this.Shoulder = value.transform.Find("Shoulder");
                    this.Chest = value.transform.Find("Chest");
                    this.LeftLeg = value.transform.Find("LeftLeg");
                    this.RightLeg = value.transform.Find("RightLeg");
                    this.LeftFoot = value.transform.Find("LeftFoot");
                    this.RightFoot = value.transform.Find("RightFoot");
                }
            }
        }

        public Transform Transform { get; private set; }

        public Transform Head { get; private set; }
        public Transform Neck { get; private set; }
        public Transform Shoulder { get; private set; }
        public Transform Chest { get; private set; }
        public Transform LeftLeg { get; private set; }
        public Transform RightLeg { get; private set; }
        public Transform LeftFoot { get; private set; }
        public Transform RightFoot { get; private set; }
    }
}