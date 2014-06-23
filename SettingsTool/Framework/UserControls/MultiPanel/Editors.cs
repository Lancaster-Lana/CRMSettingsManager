using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace LanaSoft.UserControls.MultiPanel
{
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public class InfoItemsCollection : CollectionBase
    {
        private SubItemsPanel _owner;

        public InfoItem this[int index]
        {
            get
            {
                return this.InnerList[index] as InfoItem;
            }
        }

        public InfoItemsCollection(SubItemsPanel owner)
            : base()
        {
            if (owner != null)
            {
                this._owner = owner;
            }
        }

        public InfoItemsCollection(SubItemsPanel owner, InfoItem[] items)
            : this(owner)
        {
            this.AddRange(items);
        }

        public void Add(InfoItem item)
        {
            if (item == null)
                throw new ArgumentNullException("value");

            if (item.ParentPanel == null)
                item.ParentPanel = this._owner;

            int index = this.IndexOf(item);
            if (index == -1)
                this.InnerList.Add(item);
            else
                this.InnerList[index] = item;
        }

        public void Add(InfoItemsCollection items)
        {
            if (items == null)
                throw new ArgumentNullException("Items");

            for (int i = 0; i < items.Count; i++)
            {
                this.Add(items[i]);
            }
        }

        public void AddRange(InfoItem[] items)
        {
            if (items != null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    items[i].ParentPanel = _owner;
                    this.Add(items[i]);
                }
            }
        }

        public int IndexOf(InfoItem item)
        {
            if (item != null)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i] == item)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }


        public new void Clear()
        {
            while (this.Count > 0)
            {
                this.RemoveAt(0);
            }
        }

        public bool Contains(InfoItem item)
        {
            if (item != null)
                return (this.IndexOf(item) != -1);
            return false;
        }


        public void Remove(InfoItem value)
        {
            if (value != null)
            {
                this.List.Remove(value);
            }
        }

        public new void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }


        public void Move(InfoItem value, int index)
        {
            if (value != null)
            {
                if (index < 0)
                {
                    index = 0;
                }
                else if (index > this.Count)
                {
                    index = this.Count;
                }

                if (!this.Contains(value) || this.IndexOf(value) == index)
                {
                    return;
                }

                this.List.Remove(value);

                if (index > this.Count)
                {
                    this.List.Add(value);
                }
                else
                {
                    this.List.Insert(index, value);
                }
            }
        }

        public void MoveToTop(InfoItem value)
        {
            this.Move(value, 0);
        }

        public void MoveToBottom(InfoItem value)
        {
            this.Move(value, this.Count);
        }
    }

    public class SubItemsCollectionDesigner : CollectionEditor
    {
        private SubItemsPanel _parentControl;

        // The base class has its own version of this property cached CollectionForm 
        private CollectionForm collectionForm;

        public SubItemsCollectionDesigner(Type type)
            : base(type)
        {

        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
        {
            var parentControl = (SubItemsPanel)context.Instance;
            _parentControl = parentControl;

            object returnObject = base.EditValue(context, isp, value);

            return returnObject;
        }

        protected override object CreateInstance(Type itemType)
        {
            var item = base.CreateInstance(itemType);

            ((InfoItem)item).ParentPanel = _parentControl;
            return item;
        }

        protected override object SetItems(object editValue, object[] value)
        {
            //Add InfoControls to panel => to see them
            _parentControl.subItemsLayoutPanel.Controls.Clear();
            foreach (object obj in value)
                _parentControl.AddSubItemToPanel((InfoItem)obj);
            _parentControl.subItemsLayoutPanel.ResumeLayout();
            return base.SetItems(editValue, value);
        }

        protected override CollectionForm CreateCollectionForm()
        {
            // Cache the CollectionForm being used. 
            collectionForm = base.CreateCollectionForm();
            return collectionForm;
        }
    }
}
