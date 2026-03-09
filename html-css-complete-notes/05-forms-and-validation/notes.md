# 05 Forms and Validation

## Definition
Forms are used to collect user input, and validation ensures correct data format.

## Key Points
- Use `label` with matching input `id`
- Common fields: text, email, password, select, textarea
- Validation attributes: `required`, `minlength`, `maxlength`, `pattern`

## Example Code
```html
<form action="#" method="post">
  <label for="email">Email</label>
  <input id="email" type="email" required>

  <label for="pwd">Password</label>
  <input id="pwd" type="password" minlength="6" maxlength="12" required>

  <button type="submit">Submit</button>
</form>
```

## Practice
- Add phone input with `pattern`.
- Add a required checkbox for agreement.
