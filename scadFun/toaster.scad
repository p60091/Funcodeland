include <bezier.scad>

$fa=1;
base_height = 10.0;
base_length = 15.0;
base_width = 8;
base_roundness = 3;
base_top_arc = 1;
base_side_arc = 0.1;

ControlPoints1 = [
    [-base_length/4*3,0,base_height/2,          0.1],
    [-base_length/2,0,base_height/2,            1],
    [-base_length/2*1.5,0,-base_height/4*1.5,   1],
    [0,0,-base_height/4*1.5,                    1]];
ControlPoints2 = [
    [0,0,-base_height/4*1.5,                    1],
    [base_length/2*1.5,0,-base_height/4*1.5,    1],
    [base_length/2,0,base_height/2,             1],
    [base_length/4*3,0,base_height/2,           0.1]];


function get_arc_r( chord_len, arc_h ) = 
    let(b=chord_len/2,a=arc_h) 
        (sqrt(b*b+a*a)/2) / cos(atan(b/a));
        
base_top_arc_r = get_arc_r(base_length, base_top_arc);
base_side_arc_r = get_arc_r(base_height, base_side_arc);

cube([base_length, base_width, base_height], center=true);

module base_shape() {
    intersection() {
        translate([0,0,2*base_top_arc])
            cube([base_length, base_width, base_height], center=true);
        translate([0,0,base_height/2-base_top_arc_r+base_top_arc]) 
            rotate([90,0,0]) 
                cylinder(r=base_top_arc_r, h=base_width*2, center=true);
    }

    if ( base_side_arc_r > 0 ) {
        intersection() {
            translate([-2*base_side_arc,0,0])
                cube([base_length, base_width, base_height], center=true);
            translate([-base_length/2+base_side_arc_r-base_side_arc,0,0]) 
                rotate([90,0,0]) 
                    cylinder(r=base_side_arc_r, h=base_width*2, center=true);
        }
        intersection() {
            translate([2*base_side_arc,0,0])
                cube([base_length, base_width, base_height], center=true);
            translate([base_length/2-base_side_arc_r+base_side_arc,0,0]) 
                rotate([90,0,0]) 
                    cylinder(r=base_side_arc_r, h=base_width*2, center=true);
        }
    }
}


difference() {
    minkowski() {
        base_shape();
        sphere( r=base_roundness, center=true );
    }

    BezierPoints = concat(CubicBezierPoints(ControlPoints1,10),
        CubicBezierPoints(ControlPoints2,10));
    for(i = [0:len(BezierPoints)-2]) { 
        trans0=[BezierPoints[i][0],BezierPoints[i][1],BezierPoints[i][2]];
        trans1=[BezierPoints[i+1][0],BezierPoints[i+1][1],BezierPoints[i+1][2]];

        hull() {
            translate(trans0) rotate([90,0,0]) 
                cylinder(d=BezierPoints[i][3], h=base_width*2, center=true);
            translate(trans1) rotate([90,0,0])
                cylinder(d=BezierPoints[i+1][3], h=base_width*2, center=true);
        }
    }
}