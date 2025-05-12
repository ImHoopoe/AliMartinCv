document.addEventListener('DOMContentLoaded', () => {
    const blogItems = document.querySelectorAll('.blog-item');
    const blogObserver = new IntersectionObserver((entries, observer) => {
      entries.forEach(entry => {
        if (!entry.isIntersecting) return;
        entry.target.classList.add('show');
        observer.unobserve(entry.target);
      });
    }, { threshold: 15 });
  
    blogItems.forEach(item => blogObserver.observe(item));
  });