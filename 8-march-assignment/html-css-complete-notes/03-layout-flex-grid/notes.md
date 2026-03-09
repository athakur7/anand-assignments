# 03 Layout with Flexbox and Grid

## Definition
Flexbox arranges items in one direction (row or column), while Grid arranges rows and columns together.

## Key Points
- Flexbox: `display: flex`, `justify-content`, `align-items`, `flex-wrap`
- Grid: `display: grid`, `grid-template-columns`, `gap`

## Example Code
```css
.flex-row {
  display: flex;
  gap: 12px;
  flex-wrap: wrap;
}

.grid-board {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 12px;
}
```

## Practice
- Change grid to 2 columns.
- Add more tiles and observe wrapping.
