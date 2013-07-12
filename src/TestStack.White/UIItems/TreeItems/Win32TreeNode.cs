using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.TreeItems
{
    [PlatformSpecificItem]
    public class Win32TreeNode : TreeNode
    {
        protected Win32TreeNode() {}
        public Win32TreeNode(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        //TODO Expand and Collapse also Select the node because it uses DoubleClick. Even the pattern does the same. Clicking to the left of node,
        // would not work when there is an icon to left of the node.
        protected override void DoExpand()
        {
            DoubleClick();
            if (Nodes.Count == 0)
                throw new AutomationException(string.Format("Cannot expand TreeNode {0}, expand button not visible", this), Debug.Details(AutomationElement));
        }

        protected override void DoCollapse()
        {
            DoubleClick();
        }

        protected override Point SelectPoint
        {
            get { return automationElement.Current.BoundingRectangle.Center(); }
        }
    }
}