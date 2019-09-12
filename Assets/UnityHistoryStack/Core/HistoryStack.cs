using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EditorFramework {
	public class HistoryStack {
		private Stack<ICommand> undoStack = new Stack<ICommand>();
   		private Stack<ICommand> redoStack = new Stack<ICommand>();

        public int UndoCount
        {
	        get { return undoStack.Count; }
        }

        public int RedoCount
        {
	        get { return redoStack.Count; }
        }

        public bool hasUndoCommand
		{
			get { return undoStack.Count > 0; }
		}

        public bool hasRedoCommand {
	        get { return redoStack.Count > 0; }
        }

        public void Reset()
		{
			undoStack.Clear();
			redoStack.Clear();
		}

		public void Do(ICommand cmd)
		{
			cmd.Do();
			undoStack.Push(cmd);
			redoStack.Clear();
		}

		public void Undo()
		{
			if(hasUndoCommand)
			{
				ICommand cmd = undoStack.Pop();

				cmd.Undo();
				redoStack.Push(cmd);
			}
		}

		public void Redo()
		{
			if(hasRedoCommand)
			{
				ICommand cmd = redoStack.Pop();

				cmd.Do();
				undoStack.Push(cmd);
			}
		}

		public T Spwaner<T>() where T:ICommand,new()
		{
			return new T();
		}
	}
}