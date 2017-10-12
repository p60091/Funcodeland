function CubicBezierT( P, a, t ) = let(ti = 1-t) ti*ti*ti*P[0][a]+3*ti*ti*t*P[1][a]+3*(ti)*t*t*P[2][a]+t*t*t*P[3][a];
function CubicBezierPoint( P, t ) = [for(a=[0:len(P[0])-1]) CubicBezierT( P, a, t )];
function CubicBezierPoints( P, steps ) = [for(t=[0:1.0/steps:1.0]) CubicBezierPoint(P,t)];
    
module CubicBezer(P, steps, d1,d2, h) {
    BezierPoints = CubicBezierPoints(P,steps);
    for(i = [0:len(BezierPoints)-2]) {
        hull() {
            translate(BezierPoints[i]) cylinder(d1=d1,d2=d2, h=h, center=true);
            translate(BezierPoints[i+1]) cylinder(d1=d1,d2=d2, h=h, center=true);
        }
    }
}
ControlPoints = [[0,0,0],[110,-60,0],[125,60,0],[150,65,0]];
//CubicBezer(ControlPoints,50,3,2.5,1);