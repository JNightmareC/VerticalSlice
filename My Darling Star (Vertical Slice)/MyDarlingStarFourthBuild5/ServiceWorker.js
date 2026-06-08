const cacheName = "DefaultCompany-My Darling Star (Vertical Slice)-0.1.0";
const contentToCache = [
    "Build/MyDarlingStarFourthBuild5.loader.js",
    "Build/MyDarlingStarFourthBuild5.framework.js.br",
    "Build/MyDarlingStarFourthBuild5.data.br",
    "Build/MyDarlingStarFourthBuild5.wasm.br",
    "TemplateData/style.css"

];

self.addEventListener('install', function (e) {
    console.log('[Service Worker] Install');
    
    e.waitUntil((async function () {
      const cache = await caches.open(cacheName);
      console.log('[Service Worker] Caching all: app shell and content');
      await cache.addAll(contentToCache);
    })());
});

self.addEventListener('fetch', function (e) {
    e.respondWith((async function () {
      let response = await caches.match(e.request);
      console.log(`[Service Worker] Fetching resource: ${e.request.url}`);
      if (response) { return response; }

      response = await fetch(e.request);
      const cache = await caches.open(cacheName);
      console.log(`[Service Worker] Caching new resource: ${e.request.url}`);
      cache.put(e.request, response.clone());
      return response;
    })());
});
