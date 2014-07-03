var segments : int;
var zSpacing : float;
var ySpacing : float;
var curveTypeA = false;

function New () {
	var render = GetComponent(LineRenderer);
	render.SetVertexCount(segments);
	for(i = 0.0; i < segments; i ++){
		if(curveTypeA == true){
			render.SetPosition(i, Vector3(0, i*ySpacing, i*i*zSpacing));
		}
		else{
			render.SetPosition(i, Vector3(0, (-i*(i-(segments)))/(3*segments)*ySpacing, i*zSpacing));
		}
	}
}