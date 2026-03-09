# HTML + CSS Complete Notes

This file is the master summary of beginner to advanced HTML/CSS.

## 1. HTML Basics
Definition: HTML (HyperText Markup Language) is used to structure web content.

Example:
```html
<h1>Welcome</h1>
<p>This is a paragraph.</p>
<a href="https://example.com">Visit</a>
```

## 2. CSS Basics
Definition: CSS (Cascading Style Sheets) is used to style HTML elements.

Example:
```css
h1 {
  color: #1d4ed8;
  font-size: 2rem;
}
```

## 3. Selectors and Box Model
Definition: Selectors target elements; box model controls spacing with margin, border, and padding.

Example:
```css
.card {
  margin: 12px;
  border: 2px solid #f97316;
  padding: 16px;
}
```

## 4. Layout (Flexbox and Grid)
Definition: Flexbox is one-dimensional layout; Grid is two-dimensional layout.

Example:
```css
.flex {
  display: flex;
  gap: 10px;
}

.grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 10px;
}
```

## 5. Responsive Design
Definition: Responsive design adapts layout across mobile, tablet, and desktop screens.

Example:
```css
.container {
  display: grid;
  grid-template-columns: 1fr;
}

@media (min-width: 768px) {
  .container {
    grid-template-columns: 1fr 1fr;
  }
}
```

## 6. Forms and Validation
Definition: Forms collect user input and HTML attributes help validate data before submit.

Example:
```html
<form>
  <input type="email" required>
  <input type="password" minlength="6">
  <button type="submit">Submit</button>
</form>
```

## 7. Advanced CSS
Definition: Advanced CSS includes transitions, transforms, gradients, and pseudo-elements.

Example:
```css
.button {
  transition: transform 0.3s ease;
}

.button:hover {
  transform: translateY(-2px) scale(1.03);
}
```

## 8. Mini Project Guidance
Definition: A mini project combines structure, styling, layout, responsive design, and forms.

Example sections:
- Header + navigation
- About section
- Skills grid
- Contact form

## Next Step
Open each module folder and read `notes.md` with `index.html` and `styles.css` together.
