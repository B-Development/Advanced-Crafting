namespace AdvancedCrating.Other.Recipe
{
    public class Permission
    {
        public string Value { get; set; }

        public Permission()
        {
        }

        public Permission(string value)
        {
            Value = value;
        }

        public static implicit operator string(Permission p) => p.Value;
        public static implicit operator Permission(string value) => new Permission(value);
    }
}