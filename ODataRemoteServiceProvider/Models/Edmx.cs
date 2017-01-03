using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataRemoteServiceProvider.Models.V3
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/06/edmx")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/06/edmx", IsNullable = false)]
    public partial class Edmx
    {

        private EdmxDataServices dataServicesField;

        private decimal versionField;

        /// <remarks/>
        public EdmxDataServices DataServices
        {
            get
            {
                return this.dataServicesField;
            }
            set
            {
                this.dataServicesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/06/edmx")]
    public partial class EdmxDataServices
    {

        private Schema[] schemaField;

        private decimal dataServiceVersionField;

        private decimal maxDataServiceVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Schema", Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
        public Schema[] Schema
        {
            get
            {
                return this.schemaField;
            }
            set
            {
                this.schemaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public decimal DataServiceVersion
        {
            get
            {
                return this.dataServiceVersionField;
            }
            set
            {
                this.dataServiceVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public decimal MaxDataServiceVersion
        {
            get
            {
                return this.maxDataServiceVersionField;
            }
            set
            {
                this.maxDataServiceVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2009/11/edm", IsNullable = false)]
    public partial class Schema
    {

        private SchemaEntityContainer entityContainerField;

        private SchemaEntityType[] entityTypeField;

        private SchemaAssociation[] associationField;

        private string namespaceField;

        /// <remarks/>
        public SchemaEntityContainer EntityContainer
        {
            get
            {
                return this.entityContainerField;
            }
            set
            {
                this.entityContainerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EntityType")]
        public SchemaEntityType[] EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Association")]
        public SchemaAssociation[] Association
        {
            get
            {
                return this.associationField;
            }
            set
            {
                this.associationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityContainer
    {

        private SchemaEntityContainerEntitySet[] entitySetField;

        private SchemaEntityContainerAssociationSet[] associationSetField;

        private string nameField;

        private bool isDefaultEntityContainerField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EntitySet")]
        public SchemaEntityContainerEntitySet[] EntitySet
        {
            get
            {
                return this.entitySetField;
            }
            set
            {
                this.entitySetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociationSet")]
        public SchemaEntityContainerAssociationSet[] AssociationSet
        {
            get
            {
                return this.associationSetField;
            }
            set
            {
                this.associationSetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public bool IsDefaultEntityContainer
        {
            get
            {
                return this.isDefaultEntityContainerField;
            }
            set
            {
                this.isDefaultEntityContainerField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityContainerEntitySet
    {

        private string nameField;

        private string entityTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityContainerAssociationSet
    {

        private SchemaEntityContainerAssociationSetEnd[] endField;

        private string nameField;

        private string associationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("End")]
        public SchemaEntityContainerAssociationSetEnd[] End
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Association
        {
            get
            {
                return this.associationField;
            }
            set
            {
                this.associationField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityContainerAssociationSetEnd
    {

        private string roleField;

        private string entitySetField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EntitySet
        {
            get
            {
                return this.entitySetField;
            }
            set
            {
                this.entitySetField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityType
    {

        private SchemaEntityTypeKey keyField;

        private SchemaEntityTypeProperty[] propertyField;

        private SchemaEntityTypeNavigationProperty navigationPropertyField;

        private string nameField;

        /// <remarks/>
        public SchemaEntityTypeKey Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Property")]
        public SchemaEntityTypeProperty[] Property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }

        /// <remarks/>
        public SchemaEntityTypeNavigationProperty NavigationProperty
        {
            get
            {
                return this.navigationPropertyField;
            }
            set
            {
                this.navigationPropertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityTypeKey
    {

        private SchemaEntityTypeKeyPropertyRef propertyRefField;

        /// <remarks/>
        public SchemaEntityTypeKeyPropertyRef PropertyRef
        {
            get
            {
                return this.propertyRefField;
            }
            set
            {
                this.propertyRefField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityTypeKeyPropertyRef
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityTypeProperty
    {

        private string nameField;

        private string typeField;

        private bool nullableField;

        private bool nullableFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Nullable
        {
            get
            {
                return this.nullableField;
            }
            set
            {
                this.nullableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NullableSpecified
        {
            get
            {
                return this.nullableFieldSpecified;
            }
            set
            {
                this.nullableFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaEntityTypeNavigationProperty
    {

        private string nameField;

        private string relationshipField;

        private string toRoleField;

        private string fromRoleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Relationship
        {
            get
            {
                return this.relationshipField;
            }
            set
            {
                this.relationshipField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ToRole
        {
            get
            {
                return this.toRoleField;
            }
            set
            {
                this.toRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FromRole
        {
            get
            {
                return this.fromRoleField;
            }
            set
            {
                this.fromRoleField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaAssociation
    {

        private SchemaAssociationEnd[] endField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("End")]
        public SchemaAssociationEnd[] End
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2009/11/edm")]
    public partial class SchemaAssociationEnd
    {

        private string typeField;

        private string roleField;

        private string multiplicityField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Multiplicity
        {
            get
            {
                return this.multiplicityField;
            }
            set
            {
                this.multiplicityField = value;
            }
        }
    }


}
