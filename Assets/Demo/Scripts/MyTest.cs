using System.Collections;
using System.Collections.Generic;
using EditorFramework;
using UnityEngine;

public class MyTest : MonoBehaviour {
	private HistoryStack _historyStack = new HistoryStack();
	private int i = 0;
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TestCommand cmd = _historyStack.Spwaner<TestCommand>();
			TestBuffer buffer = new TestBuffer();
			buffer.id = i;
			
			cmd.InsertBuffer(buffer);
			_historyStack.Do(cmd);
			i++;
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			_historyStack.Undo();
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			_historyStack.Redo();
		}

	}
}
