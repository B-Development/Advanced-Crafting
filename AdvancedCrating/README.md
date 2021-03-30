# Advanced Crafting

# Config:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Config xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Recipes>
    <Recipe>
      <NameOfRecipe>GPS</NameOfRecipe>
      <RewardItem>1176</RewardItem>
      <Permission>craft.GPS</Permission>
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
      <RewardItem>7</RewardItem>
      <Permission>craft.MSuppressor</Permission>
      <Ingredients>
        <Ingredient>
          <Item>149</Item>
          <Amount>2</Amount>
        </Ingredient>
        <Ingredient>
          <Item>66</Item>
          <Amount>2</Amount>
        </Ingredient>
      </Ingredients>
    </Recipe>
  </Recipes>
</Config>
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
