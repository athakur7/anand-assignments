# 02 Selectors and Box Model

## Definition
Selectors choose which elements to style, and the box model controls element spacing and size.

## Key Points
- Selectors: element, class, id, descendant
- Specificity order: inline > id > class > element
- Box model: content, padding, border, margin

## Example Code
```css
#main-title {
  color: #1f2937;
}

.card {
  margin: 16px;
  padding: 20px;
  border: 2px solid #fb923c;
}

.card h2:hover {
  color: #c2410c;
}
```

## Practice
- Add another card and style it with a class.
- Increase padding and compare element size.
