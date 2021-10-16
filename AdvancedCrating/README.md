# Advanced Crafting

# Config:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Config xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Recipes>
    <Recipe>
      <NameOfRecipe>GPS</NameOfRecipe>
      <Rewards>
        <Reward>
          <RewardItem>1176</RewardItem>
          <Amount>1</Amount>
        </Reward>
      </Rewards>
      <Permissions>
        <Permission>
          <Value>craft.GPS</Value>
        </Permission>
        <Permission>
          <Value>craft.default</Value>
        </Permission>
      </Permissions>
      <Ingredients>
        <Ingredient>
          <Item>66</Item>
          <Amount>3</Amount>
        </Ingredient>
        <Ingredient>
          <Item>1175</Item>
          <Amount>1</Amount>
        </Ingredient>
      </Ingredients>
    </Recipe>
    <Recipe>
      <NameOfRecipe>Military Suppressor</NameOfRecipe>
      <Rewards>
        <Reward>
          <RewardItem>7</RewardItem>
          <Amount>1</Amount>
        </Reward>
      </Rewards>
      <Permissions>
        <Permission>
          <Value>craft.MSuppressor</Value>
        </Permission>
      </Permissions>
      <Ingredients>
        <Ingredient>
          <Item>66</Item>
          <Amount>4</Amount>
        </Ingredient>
        <Ingredient>
          <Item>149</Item>
          <Amount>2</Amount>
        </Ingredient>
      </Ingredients>
    </Recipe>
  </Recipes>
</Config>
```

# Translation:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="no_object" Value="No object was found in your line of sight." />
  <Translation Id="storage_open" Value="Opened storage." />
  <Translation Id="invalid_storage" Value="The object that you are looking at is not a storage unit." />
  <Translation Id="successful-Craft" Value="Congratulations. You have Crafted the item." />
  <Translation Id="no-perm-for-craft" Value="You do not have permission for this craft!" />
  <Translation Id="specify-recipe" Value="Please specify a recipe." />
  <Translation Id="please-add-ingredients" Value="Player add ingredients to the storage." />
  <Translation Id="recipe-doesnt-exist" Value="This recipe does not exist." />
</Translations>
```

# Commands:
<table>
   <td>Command</td>
   <td>Permission</td>
   <td>Description</td>
   <tr>
    <td>/craft [Name Of Recipe]</td>
    <td>craft.storage</td>
    <td>Allows you to make the item</td>
   </tr>
</table>
