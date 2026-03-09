# 07 Mini Project

## Definition
A mini project is a complete page that combines HTML structure, CSS styling, layout, and responsiveness.

## Project Structure
- Header and navigation
- About section
- Skills section using Grid
- Contact form
- Mobile-friendly CSS

## Example Code
```html
<header>
  <h1>My Profile</h1>
  <nav>
    <a href="#about">About</a>
    <a href="#contact">Contact</a>
  </nav>
</header>
```

```css
.skill-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 10px;
}

@media (max-width: 640px) {
  .skill-grid {
    grid-template-columns: 1fr;
  }
}
```

## Practice
- Add one new section (Projects or Education).
- Improve colors and typography.
