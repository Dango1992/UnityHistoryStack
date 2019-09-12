using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EditorFramework {
	public class HistoryStack
	{
		private readonly int MAX_HISTORY_COUNT = 10;
		
		private List<ICommand> undoStack = new List<ICommand>();
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
			get { return UndoCount > 0; }
		}

        public bool hasRedoCommand {
	        get { return RedoCount > 0; }
        }

        public bool isHistoryOverflow {
	        get { return UndoCount > MAX_HISTORY_COUNT; }
        }

        public void Reset()
		{
			undoStack.Clear();
			redoStack.Clear();
		}

		public void Do(ICommand cmd)
		{
			cmd.Do();
			undoStack.Add(cmd);
			redoStack.Clear();
			OverflowCheck();
		}

		public void Undo()
		{
			if(hasUndoCommand)
			{
				ICommand cmd = undoStack[UndoCount-1];
				
				cmd.Undo();
				undoStack.Remove(cmd);
				redoStack.Push(cmd);
			}
		}

		public void Redo()
		{
			if(hasRedoCommand)
			{
				ICommand cmd = redoStack.Pop();

				cmd.Do();
				undoStack.Add(cmd);
			}
		}

		public T Spwaner<T>() where T:ICommand,new()
		{
			return new T();
		}

		private void OverflowCheck()
		{
			if (isHistoryOverflow)
			{
				undoStack.RemoveAt(0);
			}
		}
	}
}