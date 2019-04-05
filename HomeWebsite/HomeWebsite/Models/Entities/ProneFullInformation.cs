using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebsite.Models.Entities
{
    public class ProneFullInformation
    {
        public ProneComponent component { get; set; }
        public ProneInfo componentInfo { get; set; }
        public KategoriProne componentCategory { get; set; }
        public KonsumatorWithPicture componentPerson { get; set; }
        public Adrese componentAdress { get; set; }
        public PozicionGjeografik componentPosition { get; set; }
        public Qytet componentCity { get; set; }
        public Photo profilePhoto { get; set; }

        public ProneFullInformation()
        {

        }

        public ProneFullInformation(ProneComponent _component,ProneInfo _componentInfo,KategoriProne _componentCategory,
            KonsumatorWithPicture _componentPerson,Adrese _componentAdrese,PozicionGjeografik _componentPosition,Qytet _componentCity,Photo foto)
        {
            this.component = _component;
            this.componentInfo = _componentInfo;
            this.componentCategory = _componentCategory;
            this.componentPerson = _componentPerson;
            this.componentAdress = _componentAdrese;
            this.componentPosition = _componentPosition;
            this.componentCity = _componentCity;
            this.profilePhoto = foto;
        }
    }
}