/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./app/**/*.{html,js,ts,tsx,jsx}"],
  theme: {
    extend: {
      fontFamily:{
        main_font : ["var(--main-font)"],
      }
    },
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["cupcake", "dark", "cmyk"],
  },
}
