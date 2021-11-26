using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PipeRunner.Column
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Column/ColumnObjectList", order = -2)]

    public class ColumnObjectListSO : ScriptableObject
    {
        public List<ColumnObjectSO> list;
    }

}