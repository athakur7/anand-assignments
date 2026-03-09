# 06 Advanced CSS Effects

## Definition
Advanced CSS effects improve visual quality and interaction using motion and layered styles.

## Key Points
- CSS variables in `:root`
- Gradients for richer backgrounds
- `transition` for smooth animation
- `transform` for movement and scaling
- Pseudo-elements `::before` and `::after`

## Example Code
```css
:root {
  --accent: #f59e0b;
}

button {
  background: var(--accent);
  transition: transform 0.3s ease;
}

button:hover {
  transform: translateY(-3px);
}

.card::after {
  content: "*";
}
```

## Practice
- Change variable colors and check theme update.
- Increase hover scale effect on cards.
