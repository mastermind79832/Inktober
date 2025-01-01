using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

namespace Ottamind.Inktober
{
    public class PasswordCreator : MonoBehaviour
    {
        [SerializeField] 
        private GridLayoutGroup m_GridLayoutGroup;

        [SerializeField]
        private GameObject m_PasswordKnob;

        [SerializeField, Range(3,9)]
        private int m_GridSize;

        [SerializeField]
        private List<GameObject> m_KnobList;

		#region Create Grid
		[ContextMenu("Create Grid")]
		private void StartCreateGrid()
		{
			//clear Grid
			ClearGrid();
			//New Grid
			CreateNewGrid();

			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		}

		private void CreateNewGrid()
		{
			m_KnobList = new List<GameObject>();
			m_GridLayoutGroup.constraintCount = m_GridSize;
			int totalCount = m_GridSize * m_GridSize;
			for (int i = 0; i < totalCount; i++)
			{
				var knob = Instantiate(m_PasswordKnob);

				m_KnobList.Add(knob);
				knob.transform.SetParent(transform);	
			}
		}

		private void ClearGrid()
		{
			if (m_KnobList == null || m_KnobList.Count == 0) 
				return;

			foreach (var knob in m_KnobList)
			{
				if (knob == null)
					continue;
				DestroyImmediate(knob.gameObject);
			}

			m_KnobList.Clear();
			m_KnobList = null;
		}

		#endregion



	}
}
