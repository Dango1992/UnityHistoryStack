using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework {
	
	public struct TestBuffer
	{
		public int id;
		public GameObject target;
	}
	
	public class TestCommand : BaseCommand<TestBuffer> {
		public override void Do()
		{
			buffer.target = GameObject.CreatePrimitive(PrimitiveType.Cube);
			buffer.target.transform.position = new Vector3(buffer.id * 1.5f, buffer.id * 1.5f, buffer.id * 1.5f);
			//target=GameObject.Instantiate()
		}

		public override void Undo()
		{
			GameObject.Destroy(buffer.target);
		}
	}
}