# 04 Responsive Design

## Definition
Responsive design makes a website adapt to different screen sizes for better usability.

## Key Points
- Use viewport meta tag
- Use flexible units (`%`, `rem`, `vw`)
- Use media queries for breakpoints
- Prefer mobile-first styling

## Example Code
```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```

```css
.cards {
  display: grid;
  grid-template-columns: 1fr;
}

@media (min-width: 700px) {
  .cards {
    grid-template-columns: repeat(2, 1fr);
  }
}
```

## Practice
- Resize browser and test card layout.
- Change breakpoint to `800px` and compare.
