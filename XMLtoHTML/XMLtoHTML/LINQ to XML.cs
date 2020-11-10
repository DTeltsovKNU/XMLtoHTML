using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace XMLtoHTML
{
    class LINQ_to_XML: IXmlStrategy
    {
        public List<Students> search(Students s)
        {
            List<Students> result = new List<Students>();
            var doc = XDocument.Load(@"D:\лабы по проге\курс 2\XMLtoHTML\XMLtoHTML\XMLFile1.xml");
            var res = from obj in doc.Descendants("Student")
                      where
                      (
                      (obj.Attribute("Name").Value.Equals(s.Name) || s.Name.Equals(String.Empty)) &&
                      (obj.Attribute("Faculty").Value.Equals(s.Faculty) || s.Faculty.Equals(String.Empty)) &&
                      (obj.Attribute("Group").Value.Equals(s.Group) || s.Group.Equals(String.Empty)) &&
                      (obj.Attribute("Subject").Value.Equals(s.Subject) || s.Subject.Equals(String.Empty)) &&
                      (obj.Attribute("Mark").Value.Equals(s.Mark) || s.Mark.Equals(String.Empty))
                      )
                      select new 
                      {
                          Name = (string)obj.Attribute("Name"),
                          Faculty = (string)obj.Attribute("Faculty"),
                          Group = (string)obj.Attribute("Group"),
                          Subject = (string)obj.Attribute("Subject"),
                          Mark = (string)obj.Attribute("Mark")
                      };
            foreach(var n in res)
            {
                Students student = new Students();
                student.Name = n.Name;
                student.Faculty = n.Faculty;
                student.Group = n.Group;
                student.Subject = n.Subject;
                student.Mark = n.Mark;
                result.Add(student);
            }
            return result;
        }
    }
}
