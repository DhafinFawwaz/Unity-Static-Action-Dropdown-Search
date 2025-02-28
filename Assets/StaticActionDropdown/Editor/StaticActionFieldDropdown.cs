using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor.IMGUI.Controls;
namespace DhafinFawwaz.ActionExtension {

public class StaticActionFieldDropdown : AdvancedDropdown {
    private Action<FieldInfo> _onSelected;
    private Dictionary<Type, List<FieldInfo>> _actionFields;

    public StaticActionFieldDropdown(AdvancedDropdownState state, Dictionary<Type, List<FieldInfo>> actionFields, Action<FieldInfo> onSelected) 
        : base(state) {
        _actionFields = actionFields;
        _onSelected = onSelected;
    }

    // if its Action<int, string> OnHurt, show OnHurt<int, string>
    public static string GetConvertedName(FieldInfo fieldInfo) {
        Type fieldType = fieldInfo.FieldType;
        string genericArgs = string.Join(", ", fieldType.GetGenericArguments().Select(t => t.Name));
        return $"{fieldInfo.Name}({genericArgs})";
    }

    protected override AdvancedDropdownItem BuildRoot() {
        var root = new AdvancedDropdownItem("Select Action");

        foreach (var kvp in _actionFields) {
            Type classType = kvp.Key;
            List<FieldInfo> fields = kvp.Value;

            var classItem = new AdvancedDropdownItem(classType.Name);

            foreach (var field in fields) {
                classItem.AddChild(new AdvancedDropdownItem(GetConvertedName(field)) { id = field.MetadataToken });
            }

            root.AddChild(classItem);
        }

        return root;
    }

    protected override void ItemSelected(AdvancedDropdownItem item) {
        foreach (var kvp in _actionFields) {
            foreach (var field in kvp.Value) {
                if (field.MetadataToken == item.id) {
                    _onSelected?.Invoke(field);
                    return;
                }
            }
        }
    }
}

}