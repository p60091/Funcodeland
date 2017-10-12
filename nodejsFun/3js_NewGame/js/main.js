var container, scene, camera, renderer;
var controls;

init();
animate();


function init() {
	// setup
	container = document.getElementById( 'container' );
	scene = new THREE.Scene();
	camera = new THREE.PerspectiveCamera( 50, window.innerWidth / window.innerHeight, 0.1, 10000 );
	camera.position.z = 5;

	renderer = new THREE.WebGLRenderer( {alpha: true} );
	renderer.setSize( window.innerWidth, window.innerHeight );
	
	// load game world
	loadGame();
	
	// events
	window.addEventListener( "resize", onWindowResize, false );
	
	container.appendChild( renderer.domElement );
	document.body.appendChild( container );
}


function animate() {
	requestAnimationFrame( animate );
	
	if( controls )
		controls.update();
	render();
}

function render() {
	renderer.clear();
	renderer.render( scene, camera );
}

function onWindowResize() {
	camera.aspect = window.innerWidth / window.innterHeight;
	camera.updateProjectionMatrix();
	
	renderer.setSize( window.innerWidth, window.innerHeight );
}