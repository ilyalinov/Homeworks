using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueListNamespace
{
    public class UniqueListClass : List
    {
        /// <summary>
        /// An exception that generated when you delete nonexistent item
        /// </summary>
        [Serializable]
        public class ElementDoesntExistException : ApplicationException
        {
            public ElementDoesntExistException()
            {
            }

            public ElementDoesntExistException(string message) : base(message)
            {
            }
        }

        /// <summary>
        /// An exception that generated when you add an existing item
        /// </summary>
        [Serializable]
        public class AddExistentElementException : ApplicationException
        {
            public AddExistentElementException()
            {
            }

            public AddExistentElementException(string message)
                : base(message)
            {
            }
        }

        /// <summary>
        /// Insert key to the unique list
        /// </summary>
        /// <param name="key"> Inserted key </param>
        public override void Insert(int key)
        {
            if (base.Search(key))
            {
                throw new AddExistentElementException("Such element already exists in your list");
            }
            else
            {
                base.Insert(key);
            }
        }

        /// <summary>
        /// Delete key from the list
        /// </summary>
        /// <param name="key"> Deleted key </param>
        public override void Delete(int key)
        {
            var deletedElement = base.SearchListElement(key);
            if (deletedElement == null)
            {
                throw new ElementDoesntExistException("Such element doesn't exist");
            }
            else
            {
                Console.WriteLine("Deleted element with key: " + deletedElement.Key);
                if (deletedElement.Prev == null)
                {
                    this.head = deletedElement.Next;
                }
                else
                {
                    deletedElement.Prev.Next = deletedElement.Next;
                }
                if (deletedElement.Next != null)
                {
                    deletedElement.Next.Prev = deletedElement.Prev;
                }
                this.numberOfElems--;
            }
        }
    }
}
