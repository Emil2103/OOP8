using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OOP8
{
    public partial class MyTreeView : TreeView, IObserver, ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        public int selected;
        protected Form1 currentForm;

        public MyTreeView(Form1 form)
        {
            currentForm = form;
        }

        public void PaintBranch(TreeNode nd, Color color)
        {
            nd.ForeColor = color;
            foreach(TreeNode node in nd.Nodes)
            {
                PaintBranch(node, color);
            }
        }

        public void processNode(TreeNode node, Object obj)
        {
            if (obj != null)
            {
                node.Text = obj.getID().ToString() + " x: " + obj.getX().ToString() + " y: " + obj.getY().ToString();
                if (obj.getSelect() == true)
                {
                    node.ForeColor = Color.Red;
                    node.Checked = true;
                }
                else
                    node.ForeColor = Color.Black;
                if (obj is CGroup)
                {
                    Storage st = (obj as CGroup).getShape();
                    st.count = (obj as CGroup).count;
                    for (int i = 0; i < st.count; i++)
                    {
                        TreeNode NewNode = new TreeNode();
                        processNode(NewNode, st.obj[i]);
                        node.Nodes.Add(NewNode);
                    }
                }
            }
            
        }

        public void onSubjectChanged(ISubject subject)
        {
            if(subject is Storage)
            {
                this.Nodes.Clear();
                for(int i=0; i < (subject as Storage).count; i++)
                {
                    TreeNode newNode = new TreeNode();
                    processNode(newNode, (subject as Storage).obj[i]);
                    this.Nodes.Add(newNode); 
                }
                return;
            }
        }

        public void addObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void notifyEveryone()
        {
            for (int i = 0; i < observers.Count; i++)
                observers[i].onSubjectChanged(this);
            currentForm.Invalidate();
        }
    }
}
