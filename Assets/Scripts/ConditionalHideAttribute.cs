using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute {

	// The name of the Bool field that will be in control
	public string ConditionalSourceField = "";
	// if TRUE = Hide in Inspector / if FALSE = Disable in Inspector
	public bool HideInInspector = false;

	public ConditionalHideAttribute (string conditionalSourceField){
		this.ConditionalSourceField = conditionalSourceField;
		this.HideInInspector = false;
	}
	public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector){
		this.ConditionalSourceField = conditionalSourceField;
		this.HideInInspector = hideInInspector;
	}
}
