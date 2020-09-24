using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemConfiguratorView : MonoBehaviour
{
    [SerializeField] ItemInstance3D targetItem;

    [SerializeField] InputField idText;
    [SerializeField] InputField nameText;
    [SerializeField] InputField massText;
    [SerializeField] Dropdown typeSelector;


    void Start()
    {
        CloneData();
        DisplaySourceData();
        AddOnChangedReferences();
    }

    //copy data to prevent source resources modification
    void CloneData() => targetItem.data = Instantiate(targetItem.data);

    void DisplaySourceData()
    {
        ref var targetData = ref targetItem.data;
        idText.text = targetData.id.ToString();
        nameText.text = targetData.name;

        LoadTypeOptions();
        typeSelector.value = targetData.groupIndex;
        
        massText.text = targetItem.rigidbody.mass.ToString(CultureInfo.InvariantCulture);
    }

    void AddOnChangedReferences()
    {
        idText.onValueChanged.AddListener((tempId => targetItem.data.id = int.Parse(tempId)));
        nameText.onValueChanged.AddListener((tempName => targetItem.data.name = tempName));
        massText.onValueChanged.AddListener((tempMass => targetItem.rigidbody.mass = float.Parse(tempMass)));
        typeSelector.onValueChanged.AddListener((tempId => targetItem.data.groupIndex = tempId));
    }

    void LoadTypeOptions() => typeSelector.AddOptions(ItemGroupsStorage.GetAllGroupsNames().ToList());
}
