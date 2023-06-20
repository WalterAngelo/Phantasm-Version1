using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Instruction Object", menuName = "Instruction")]
public class InstructionObject : ScriptableObject
{
    public string instructionName;
    [TextArea(15, 20)]
    public string instructionDescription;
}
