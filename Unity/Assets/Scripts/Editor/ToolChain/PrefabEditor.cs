using System.Collections;
using System.Collections.Generic;
using Animancer;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class PrefabEditor : OdinEditorWindow
    {
        [LabelText("模型（fbx）"), PropertyOrder(1.1f)]
        public GameObject fbx;

        [LabelText("预设编号"), PropertyOrder(1.2f)]
        public string prefabId;

        [LabelText("是否是主角"), PropertyOrder(1.3f)]
        public bool isRole;
        
        [Button("导出Unit预设"), PropertyOrder(1.4f)]
        public void ExportUnit()
        {
            if (fbx == null)
            {
                EditorHelper.LogError("请设置fbx文件！");
                return;
            }

            GameObject instance = new();
            this._previewGo.transform.SetParent(instance.transform);
            _previewGo.name = this.fbx.name;

            instance.layer = LayerMask.NameToLayer("Unit");

            Animator animator = _previewGo.GetComponent<Animator>();
            if (animator == null)
            {
                animator = _previewGo.AddComponent<Animator>();
            }

            CharacterController characterController = instance.AddComponent<CharacterController>();
            characterController.center = Vector3.up;

            string prefabName = fbx.name;
            if (!string.IsNullOrEmpty(this.prefabId))
            {
                prefabName = this.prefabId;
            }

            instance.name = prefabName;

            ReferenceCollector collector = instance.AddComponent<ReferenceCollector>();
            collector.Add("Model", _previewGo);
            collector.Add("Animator", animator);
            collector.Add("CharacterController", characterController);
            
            AnimancerComponent animancer = _previewGo.AddComponent<AnimancerComponent>();
            collector.Add("AnimancerComponent", animancer);
            
            // 设置相机焦点
            if (isRole)
            {
                GameObject cameraLookAt = new("CameraLookAt");
                cameraLookAt.transform.SetParent(instance.transform);
                cameraLookAt.transform.localPosition = new Vector3(0, 1, 0);
                
                collector.Add("CameraLookAt", cameraLookAt);
            }

            string prefabPath = $"Assets/Bundles/Unit/{prefabName}.prefab";

            DeletePart();

            PrefabUtility.SaveAsPrefabAsset(instance, prefabPath);

            UnityEngine.Object.DestroyImmediate(instance);

            EditorHelper.Log("导出Unit成功！");
        }

        private const string BodyParentPath = "";
        private const string HeadParentPath = "Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Neck/Bip001 Head/HEAD_CONTAINER";

        private const string LeftHandParentPath =
                "Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Clavicle/Bip001 L UpperArm/Bip001 L Forearm/Bip001 L Hand/L_hand_container";

        private const string LeftShieldParentPath =
                "Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Clavicle/Bip001 L UpperArm/Bip001 L Forearm/Bip001 L Hand/L_shield_container";

        private const string RightHandParentPath =
                "Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/R_hand_container";

        private const string BackpackParentPath = "Bip001/Bip001 Pelvis/Bip001 Spine/Backpack_container";

        private enum UnitPart
        {
            Body,
            Head,
            LeftHand,
            LeftShield,
            RightHand,
            Back,
        }

        [LabelText("头"), ValueDropdown("GetHeads"), OnValueChanged("OnHeadChanged"), PropertyOrder(2.1f)]
        public string head;

        public IEnumerable GetHeads()
        {
            List<string> heads = new List<string>();

            if (!this._unitChildren.ContainsKey(UnitPart.Head))
            {
                return heads;
            }

            foreach (var kv in this._unitChildren[UnitPart.Head])
            {
                heads.Add(kv.Key);
            }

            return heads;
        }

        public void OnHeadChanged()
        {
            if (string.IsNullOrEmpty(head))
            {
                return;
            }
            
            if (!this._unitChildren.ContainsKey(UnitPart.Head))
            {
                return;
            }
            
            foreach (var kv in this._unitChildren[UnitPart.Head])
            {
                kv.Value.SetActive(kv.Key.Equals(this.head));
            }
        }

        [LabelText("身体"), ValueDropdown("GetBodies"), OnValueChanged("OnBodyChanged"), PropertyOrder(2.2f)]
        public string body;
        
        public IEnumerable GetBodies()
        {
            List<string> heads = new List<string>();

            if (!this._unitChildren.ContainsKey(UnitPart.Body))
            {
                return heads;
            }

            foreach (var kv in this._unitChildren[UnitPart.Body])
            {
                heads.Add(kv.Key);
            }

            return heads;
        }

        public void OnBodyChanged()
        {
            if (string.IsNullOrEmpty(this.body))
            {
                return;
            }
            
            if (!this._unitChildren.ContainsKey(UnitPart.Body))
            {
                return;
            }
            
            foreach (var kv in this._unitChildren[UnitPart.Body])
            {
                kv.Value.SetActive(kv.Key.Equals(this.body));
            }
        }

        [LabelText("左手武器"), ValueDropdown("GetLeftHand"), OnValueChanged("OnLeftHandChanged"), PropertyOrder(2.3f)]
        public string leftHand;
        
        public IEnumerable GetLeftHand()
        {
            List<string> heads = new List<string>();
            
            heads.Add("None");

            if (!this._unitChildren.ContainsKey(UnitPart.LeftHand))
            {
                return heads;
            }

            foreach (var kv in this._unitChildren[UnitPart.LeftHand])
            {
                heads.Add(kv.Key);
            }

            return heads;
        }

        public void OnLeftHandChanged()
        {
            if (string.IsNullOrEmpty(leftHand))
            {
                return;
            }
            
            if (!this._unitChildren.ContainsKey(UnitPart.LeftHand))
            {
                return;
            }
            
            foreach (var kv in this._unitChildren[UnitPart.LeftHand])
            {
                kv.Value.SetActive(kv.Key.Equals(this.leftHand));
            }
        }
        
        [LabelText("左手盾牌"), ValueDropdown("GetLeftShield"), OnValueChanged("OnLeftShieldChanged"), PropertyOrder(2.3f)]
        public string leftShield;
        
        public IEnumerable GetLeftShield()
        {
            List<string> heads = new List<string>();
            
            heads.Add("None");

            if (!this._unitChildren.ContainsKey(UnitPart.LeftShield))
            {
                return heads;
            }

            foreach (var kv in this._unitChildren[UnitPart.LeftShield])
            {
                heads.Add(kv.Key);
            }

            return heads;
        }

        public void OnLeftShieldChanged()
        {
            if (string.IsNullOrEmpty(this.leftShield))
            {
                return;
            }
            
            if (!this._unitChildren.ContainsKey(UnitPart.LeftShield))
            {
                return;
            }
            
            foreach (var kv in this._unitChildren[UnitPart.LeftShield])
            {
                kv.Value.SetActive(kv.Key.Equals(this.leftShield));
            }
        }

        [LabelText("右手"), ValueDropdown("GetRightHead"), OnValueChanged("OnRightHandChanged"), PropertyOrder(2.4f)]
        public string rightHand;
        
        public IEnumerable GetRightHead()
        {
            List<string> heads = new List<string>();
            
            heads.Add("None");

            if (!this._unitChildren.ContainsKey(UnitPart.RightHand))
            {
                return heads;
            }

            foreach (var kv in this._unitChildren[UnitPart.RightHand])
            {
                heads.Add(kv.Key);
            }

            return heads;
        }

        public void OnRightHandChanged()
        {
            if (string.IsNullOrEmpty(this.rightHand))
            {
                return;
            }
            
            if (!this._unitChildren.ContainsKey(UnitPart.RightHand))
            {
                return;
            }
            
            foreach (var kv in this._unitChildren[UnitPart.RightHand])
            {
                kv.Value.SetActive(kv.Key.Equals(this.rightHand));
            }
        }

        [LabelText("背部"), ValueDropdown("GetBack"), OnValueChanged("OnBackpackChanged"), PropertyOrder(2.5f)]
        public string back;
        
        public IEnumerable GetBack()
        {
            List<string> heads = new List<string>();
            
            heads.Add("None");

            if (!this._unitChildren.ContainsKey(UnitPart.Back))
            {
                return heads;
            }

            foreach (var kv in this._unitChildren[UnitPart.Back])
            {
                heads.Add(kv.Key);
            }

            return heads;
        }

        public void OnBackpackChanged()
        {
            if (string.IsNullOrEmpty(this.back))
            {
                return;
            }
            
            if (!this._unitChildren.ContainsKey(UnitPart.Back))
            {
                return;
            }
            
            foreach (var kv in this._unitChildren[UnitPart.Back])
            {
                kv.Value.SetActive(kv.Key.Equals(this.back));
            }
        }

        private Dictionary<UnitPart, Dictionary<string, GameObject>> _unitChildren = new();

        private GameObject _previewGo;

        [Button("预览Unit"), PropertyOrder(2.6f)]
        public void Preview()
        {
            _unitChildren.Clear();
            _unitChildren.Add(UnitPart.Body, new Dictionary<string, GameObject>());
            _unitChildren.Add(UnitPart.Head, new Dictionary<string, GameObject>());
            _unitChildren.Add(UnitPart.LeftHand, new Dictionary<string, GameObject>());
            _unitChildren.Add(UnitPart.LeftShield, new Dictionary<string, GameObject>());
            _unitChildren.Add(UnitPart.RightHand, new Dictionary<string, GameObject>());
            _unitChildren.Add(UnitPart.Back, new Dictionary<string, GameObject>());

            if (_previewGo != null)
            {
                UnityEngine.Object.DestroyImmediate(_previewGo);
                this._previewGo = null;
            }

            _previewGo = Instantiate(fbx);
            Transform transform = _previewGo.transform;

            Initialization(transform);
        }

        private void Initialization(Transform transform)
        {
            // body
            SetUnitPart(transform, UnitPart.Body, "Body_");

            // head
            Transform headParent = transform.Find(HeadParentPath);
            SetUnitPart(headParent, UnitPart.Head, "Head_");

            // left hand
            Transform leftHandParent = transform.Find(LeftHandParentPath);
            SetUnitPart(leftHandParent, UnitPart.LeftHand, "w_");

            // left shield
            Transform leftShieldParent = transform.Find(LeftShieldParentPath);
            SetUnitPart(leftShieldParent, UnitPart.LeftShield, "shield_");

            // right hand
            Transform rightHandParent = transform.Find(RightHandParentPath);
            SetUnitPart(rightHandParent, UnitPart.RightHand, "w_");

            // back
            Transform backParent = transform.Find(BackpackParentPath);
            SetUnitPart(backParent, UnitPart.Back, "quiver_");
        }

        private void SetUnitPart(Transform parent, UnitPart part, string prefix)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (!child.name.StartsWith(prefix))
                {
                    continue;
                }

                _unitChildren[part].Add(child.name, child.gameObject);
            }
        }

        private void DeletePart()
        {
            if (this._previewGo == null)
            {
                return;
            }

            foreach (var kv in this._unitChildren)
            {
                foreach (var kv1 in kv.Value)
                {
                    if (!kv1.Value.activeSelf)
                    {
                        UnityEngine.Object.DestroyImmediate(kv1.Value);
                    }
                }
            }
        }
    }
}