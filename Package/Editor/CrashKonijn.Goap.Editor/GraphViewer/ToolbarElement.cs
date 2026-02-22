using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace CrashKonijn.Goap.Editor
{
    public class ToolbarElement : Toolbar
    {
        public ToolbarElement(EditorWindowValues values)
        {
            this.Add(new ToolbarButton(() =>
            {
                Selection.activeObject = values.SelectedObject;
            })
            {
                text = values.SelectedObject.name,
            });

            this.Add(new ToolbarButton(() =>
            {
                var elementsWithClass = values.RootElement.Query<NodeElement>(className: "node-element").ToList();

                foreach (var element in elementsWithClass)
                {
                    element.isCollapsed = true;
                }
            })
            {
                text = "collapse",
            });

            this.Add(new ToolbarButton(() =>
            {
                var elementsWithClass = values.RootElement.Query<NodeElement>(className: "node-element").ToList();

                foreach (var element in elementsWithClass)
                {
                    element.isCollapsed = false;
                }
            })
            {
                text = "open",
            });

            ToolbarButton configToggle = null;
            configToggle = new ToolbarButton(() =>
            {
                values.ShowConfig = !values.ShowConfig;
                configToggle.text = values.ShowConfig ? "Config (true)" : "Config (false)";
            })
            {
                text = "toggle config",
            };

            this.Add(configToggle);
            
            
            ToolbarButton showOnlyGoalToggle = null;
            showOnlyGoalToggle = new ToolbarButton(() =>
            {
                values.ShowOnlyGoal = !values.ShowOnlyGoal;
                showOnlyGoalToggle.text = values.ShowOnlyGoal ? "Show only Goal (true)" : "Show only Goal (false)";
            })
            {
                text = "Show only Goal",
            };

            this.Add(showOnlyGoalToggle);

            var spacer = new VisualElement();
            spacer.style.flexGrow = 1; // This makes the spacer flexible, filling available space
            this.Add(spacer);

            this.Add(new ToolbarButton(() =>
            {
                values.UpdateZoom(10);
            })
            {
                text = "+",
            });
            this.Add(new ToolbarButton(() =>
            {
                values.UpdateZoom(-10);
            })
            {
                text = "-",
            });
            this.Add(new ToolbarButton(() =>
            {
                values.Zoom = 100;
                values.DragDrawer.Reset();
            })
            {
                text = "reset",
            });
        }
    }
}
