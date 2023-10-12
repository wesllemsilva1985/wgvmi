$(document).ready(function () {
    const $carousel = $('.carousel');
    const $slide = $('.slide');
    const slideCount = $slide.length;
    const slideWidth = 250 + 10; /* Largura da imagem + margem */
    let currentIndex = 0;

    $('.next-button').on('click', function (e) {
        e.preventDefault();
        currentIndex = (currentIndex + 1) % slideCount;
        updateCarousel();
    });

    $('.prev-button').on('click', function (e) {
        e.preventDefault();
        currentIndex = (currentIndex - 1 + slideCount) % slideCount;
        updateCarousel();
    });

    // Função para atualizar o carrossel
    function updateCarousel() {
        const translateX = -(currentIndex * slideWidth);
        $slide.css('transform', `translateX(${translateX}px)`);
    }
});
