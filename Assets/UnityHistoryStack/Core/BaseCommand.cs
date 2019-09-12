using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
	public class BaseCommand<T> : ICommand {
		protected T buffer;

		public void InsertBuffer(T buffer)
		{
			this.buffer = buffer;
		}

		public virtual void Do()
		{
			
		}

		public virtual void Undo()
		{
			
		}
	}
}

