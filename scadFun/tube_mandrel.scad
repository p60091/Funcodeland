buffer = 3;
buffer2 = 1.5;
$fn=100;

module spindle_profile( tube_d, inner_bend_r ) {
    difference() {
        square(size=[tube_d/2+inner_bend_r+buffer2, tube_d+buffer*2], center=false);
        translate([tube_d/2+inner_bend_r, tube_d/2+buffer]) 
            circle(d=tube_d);
        translate([tube_d/2+inner_bend_r, buffer])
            square(size=[buffer2*2, tube_d], center=false);
        
    }
    translate([tube_d/2+inner_bend_r+buffer2, buffer/2])
            circle(d=buffer, center=false);
    translate([tube_d/2+inner_bend_r+buffer2, tube_d+3*buffer/2])
            circle(d=buffer, center=false);
}

module spindle(tube_d, inner_bend_r, ang ){
    rotate_extrude(angle=ang) spindle_profile( tube_d, inner_bend_r  );
}

module side(tube_d, inner_bend_r, length ){
    translate([0,0,tube_d+buffer*2]) rotate ([0,90,0]) linear_extrude(length) rotate(-90) spindle_profile( tube_d, inner_bend_r  );
}


module form_90_135( side_length, tube_d, inner_bend_r ){
    rotate (180-1) spindle( tube_d, inner_bend_r, 90+2 );
    translate([side_length,0,0]) rotate(-90-1) spindle( tube_d, inner_bend_r, 112.5+2 );
    translate([0,side_length,0]) rotate (67.5-1) spindle( tube_d, inner_bend_r, 112.5+2 );
    a = sin(45) * side_length;
    c = a / sin(67.5);
    b = a / tan(67.5);
    translate([cos(45)*(a+b),sin(45)*(a+b),0]) rotate (22.5-1) spindle( tube_d, inner_bend_r, 45+2 );
    
    side( tube_d, inner_bend_r, side_length );
    rotate(90) mirror([0,-1,0]) side( tube_d, inner_bend_r, side_length );
    translate([cos(45)*(a+b),sin(45)*(a+b),0]) rotate(157.5) side( tube_d, inner_bend_r, c );
    translate([cos(45)*(a+b),sin(45)*(a+b),0]) rotate(-67.5) mirror([0,-1,0]) side( tube_d, inner_bend_r, c );
}

module form_A_B( side_length, tube_d, inner_bend_r, A, B ){
    A2 = 180-A;
    B2 = 180-B;
	C = 180 - (A+B)/2;
    C2 = 180-C;
	a = sin(A/2) * side_length;
    c = a / sin(B/2);
    b = a / tan(B/2);
	
    rotate ((90-A2)/2-180) spindle( tube_d, inner_bend_r, A2 );
	translate([cos(45)*(a+b),sin(45)*(a+b),0]) rotate ((90-B2)/2) spindle( tube_d, inner_bend_r, B2 );
    
    
    rotate (-(90-A2)/2) side( tube_d, inner_bend_r, side_length );
    rotate ((90-A2)/2+90) mirror([0,1,0]) side( tube_d, inner_bend_r, side_length );
    
    translate([cos(45)*(a+b),sin(45)*(a+b),0]) rotate (-(90-B2)/2+180) side( tube_d, inner_bend_r, c );
    translate([cos(45)*(a+b),sin(45)*(a+b),0]) rotate (-(90-B2)/2+180+90) mirror([0,1,0]) side( tube_d, inner_bend_r, c );
    
    //rotate(90) mirror([0,-1,0]) side( tube_d, inner_bend_r, side_length );
    
    //rotate (B2*2-1) spindle( tube_d, inner_bend_r, B2+2 );
}

form_A_B(30, 16, 6,125, 135);