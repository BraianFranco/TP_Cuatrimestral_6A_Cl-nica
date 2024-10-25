
const preferedColorScheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
const slider = document.getElementById('slider');

const setTheme = (theme) => {
    document.documentElement.setAttribute('data-theme', theme);
    localStorage.setItem('theme', theme);



    // Actualizamos el slider según el tema
    slider.checked = theme === 'dark';
};

slider.addEventListener('change', () => {
    let switchToTheme = slider.checked ? 'dark' : 'light';
    setTheme(switchToTheme);
});

// Inicializar tema
setTheme(localStorage.getItem('theme') || preferedColorScheme);
