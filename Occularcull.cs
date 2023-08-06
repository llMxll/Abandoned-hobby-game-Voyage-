using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occularcull : MonoBehaviour {

    public float height;

    public Vector3 upleft1object;
    public Vector3 upleft2object;
    public Vector3 upleft3object;
    public Vector3 upleft4object;
    public Vector3 upleft5object;
    public Vector3 upleft6object;
    public Vector3 upleft7object;

    public Vector3 leftdown1object;
    public Vector3 leftdown2object;
    public Vector3 leftdown3object;
    public Vector3 leftdown4object;
    public Vector3 leftdown5object;
    public Vector3 leftdown6object;
    public Vector3 leftdown7object;

    public Vector3 downright1object;
    public Vector3 downright2object;
    public Vector3 downright3object;
    public Vector3 downright4object;
    public Vector3 downright5object;
    public Vector3 downright6object;
    public Vector3 downright7object;

    public Vector3 rightup1object;
    public Vector3 rightup2object;
    public Vector3 rightup3object;
    public Vector3 rightup4object;
    public Vector3 rightup5object;
    public Vector3 rightup6object;
    public Vector3 rightup7object;

    void Start () {

	}
	
	void Update () {

        RaycastHit hitupleft1;
        RaycastHit hitupleft2;
        RaycastHit hitupleft3;
        RaycastHit hitupleft4;
        RaycastHit hitupleft5;
        RaycastHit hitupleft6;
        RaycastHit hitupleft7;
        
        RaycastHit hitleftdown1;
        RaycastHit hitleftdown2;
        RaycastHit hitleftdown3;
        RaycastHit hitleftdown4;
        RaycastHit hitleftdown5;
        RaycastHit hitleftdown6;
        RaycastHit hitleftdown7;

        RaycastHit hitdownright1;
        RaycastHit hitdownright2;
        RaycastHit hitdownright3;
        RaycastHit hitdownright4;
        RaycastHit hitdownright5;
        RaycastHit hitdownright6;
        RaycastHit hitdownright7;

        RaycastHit hitrightup1;
        RaycastHit hitrightup2;
        RaycastHit hitrightup3;
        RaycastHit hitrightup4;
        RaycastHit hitrightup5;
        RaycastHit hitrightup6;
        RaycastHit hitrightup7;


        // Draw raycasts
        Vector3 upleft1 = Quaternion.AngleAxis(3, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, upleft1, Color.green);
        Vector3 upleft2 = Quaternion.AngleAxis(15, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, upleft2, Color.green);
        Vector3 upleft3 = Quaternion.AngleAxis(30, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, upleft3, Color.green);
        Vector3 upleft4 = Quaternion.AngleAxis(45, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, upleft4, Color.green);
        Vector3 upleft5 = Quaternion.AngleAxis(60, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, upleft5, Color.green);
        Vector3 upleft6 = Quaternion.AngleAxis(75, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, upleft6, Color.green);
        Vector3 upleft7 = Quaternion.AngleAxis(87, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, upleft7, Color.green);


        Vector3 leftdown1 = Quaternion.AngleAxis(93, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, leftdown1, Color.green);
        Vector3 leftdown2 = Quaternion.AngleAxis(105, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, leftdown2, Color.green);
        Vector3 leftdown3 = Quaternion.AngleAxis(120, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, leftdown3, Color.green);
        Vector3 leftdown4 = Quaternion.AngleAxis(135, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, leftdown4, Color.green);
        Vector3 leftdown5 = Quaternion.AngleAxis(150, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, leftdown5, Color.green);
        Vector3 leftdown6 = Quaternion.AngleAxis(165, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, leftdown6, Color.green);
        Vector3 leftdown7 = Quaternion.AngleAxis(177, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, leftdown7, Color.green);


        Vector3 downright1 = Quaternion.AngleAxis(183, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, downright1, Color.green);
        Vector3 downright2 = Quaternion.AngleAxis(195, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, downright2, Color.green);
        Vector3 downright3 = Quaternion.AngleAxis(210, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, downright3, Color.green);
        Vector3 downright4 = Quaternion.AngleAxis(225, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, downright4, Color.green);
        Vector3 downright5 = Quaternion.AngleAxis(240, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, downright5, Color.green);
        Vector3 downright6 = Quaternion.AngleAxis(255, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, downright6, Color.green);
        Vector3 downright7 = Quaternion.AngleAxis(267, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, downright7, Color.green);


        Vector3 rightup1 = Quaternion.AngleAxis(273, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, rightup1, Color.green);
        Vector3 rightup2 = Quaternion.AngleAxis(285, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, rightup2, Color.green);
        Vector3 rightup3 = Quaternion.AngleAxis(300, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, rightup3, Color.green);
        Vector3 rightup4 = Quaternion.AngleAxis(315, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, rightup4, Color.green);
        Vector3 rightup5 = Quaternion.AngleAxis(330, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, rightup5, Color.green);
        Vector3 rightup6 = Quaternion.AngleAxis(345, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, rightup6, Color.green);
        Vector3 rightup7 = Quaternion.AngleAxis(357, transform.forward) * transform.up * 12;
        Debug.DrawRay(transform.position, rightup7, Color.green);

        //Cast ray  and find hit positions
        if (Physics.Raycast(transform.position, (upleft1), out hitupleft1))
        {upleft1object = hitupleft1.point;}
        else { upleft1object = transform.position + upleft1; }
        if (Physics.Raycast(transform.position, (upleft2), out hitupleft2))
        { upleft2object = hitupleft2.point;}
        else { upleft2object = transform.position + upleft2; }
        if (Physics.Raycast(transform.position, (upleft3), out hitupleft3))
        {upleft3object = hitupleft3.point;}
        else { upleft3object = transform.position + upleft3; }
        if (Physics.Raycast(transform.position, (upleft4), out hitupleft4))
        {upleft4object = hitupleft4.point;}
        else { upleft4object = transform.position + upleft4; }
        if (Physics.Raycast(transform.position, (upleft5), out hitupleft5))
        {upleft5object = hitupleft5.point;}
        else { upleft5object = transform.position + upleft5; }
        if (Physics.Raycast(transform.position, (upleft6), out hitupleft6))
        { upleft6object = hitupleft6.point; }
        else { upleft6object = transform.position + upleft6; }
        if (Physics.Raycast(transform.position, (upleft7), out hitupleft7))
        { upleft7object = hitupleft7.point; }
        else { upleft7object = transform.position + upleft7; }

        if (Physics.Raycast(transform.position, (leftdown1), out hitleftdown1))
        { leftdown1object = hitleftdown1.point; }
        else { leftdown1object = transform.position + leftdown1; }
        if (Physics.Raycast(transform.position, (leftdown2), out hitleftdown2))
        { leftdown2object = hitleftdown2.point; }
        else { leftdown2object = transform.position + leftdown2; }
        if (Physics.Raycast(transform.position, (leftdown3), out hitleftdown3))
        { leftdown3object = hitleftdown3.point; }
        else { leftdown3object = transform.position + leftdown3; }
        if (Physics.Raycast(transform.position, (leftdown4), out hitleftdown4))
        { leftdown4object = hitleftdown4.point; }
        else { leftdown4object = transform.position + leftdown4; }
        if (Physics.Raycast(transform.position, (leftdown5), out hitleftdown5))
        { leftdown5object = hitleftdown5.point; }
        else { leftdown5object = transform.position + leftdown5; }
        if (Physics.Raycast(transform.position, (leftdown6), out hitleftdown6))
        { leftdown6object = hitleftdown6.point; }
        else { leftdown6object = transform.position + leftdown6; }
        if (Physics.Raycast(transform.position, (leftdown7), out hitleftdown7))
        { leftdown7object = hitleftdown7.point; }
        else { leftdown7object = transform.position + leftdown7; }

        if (Physics.Raycast(transform.position, (downright1), out hitdownright1))
        { downright1object = hitdownright1.point; }
        else { downright1object = transform.position + downright1; }
        if (Physics.Raycast(transform.position, (downright2), out hitdownright2))
        { downright2object = hitdownright2.point; }
        else { downright2object = transform.position + downright2; }
        if (Physics.Raycast(transform.position, (downright3), out hitdownright3))
        { downright3object = hitdownright3.point; }
        else { downright3object = transform.position + downright3; }
        if (Physics.Raycast(transform.position, (downright4), out hitdownright4))
        { downright4object = hitdownright4.point; }
        else { downright4object = transform.position + downright4; }
        if (Physics.Raycast(transform.position, (downright5), out hitdownright5))
        { downright5object = hitdownright5.point; }
        else { downright5object = transform.position + downright5; }
        if (Physics.Raycast(transform.position, (downright6), out hitdownright6))
        { downright6object = hitdownright6.point; }
        else { downright6object = transform.position + downright6; }
        if (Physics.Raycast(transform.position, (downright7), out hitdownright7))
        { downright7object = hitdownright7.point; }
       else { downright7object = transform.position + downright7; }

        if (Physics.Raycast(transform.position, (rightup1), out hitrightup1))
        { rightup1object = hitrightup1.point; }
       else { rightup1object = transform.position + rightup1; }
        if (Physics.Raycast(transform.position, (rightup2), out hitrightup2))
        { rightup2object = hitrightup2.point; }
        else { rightup2object = transform.position + rightup2; }
        if (Physics.Raycast(transform.position, (rightup3), out hitrightup3))
        { rightup3object = hitrightup3.point; }
        else { rightup3object = transform.position + rightup3; }
        if (Physics.Raycast(transform.position, (rightup4), out hitrightup4))
        { rightup4object = hitrightup4.point; }
        else { rightup4object = transform.position + rightup4; }
        if (Physics.Raycast(transform.position, (rightup5), out hitrightup5))
        { rightup5object = hitrightup5.point; }
        else { rightup5object = transform.position + rightup5; }
        if (Physics.Raycast(transform.position, (rightup6), out hitrightup6))
        { rightup6object = hitrightup6.point; }
        else { rightup6object = transform.position + rightup6; }
        if (Physics.Raycast(transform.position, (rightup7), out hitrightup7))
        { rightup7object = hitrightup7.point; }
        else { rightup7object = transform.position + rightup7; }

        //make mesh
        MeshFilter mf = GetComponent<MeshFilter>();

        Mesh fieldofview = new Mesh();
        fieldofview.Clear();
        mf.mesh = fieldofview;

        //      verticies
        Vector3[] verticies = new Vector3[56]
        {
            //top
            new Vector3 (upleft1object.x - transform.position.x -10, upleft1object.y - transform.position.y +10, upleft1object.z - transform.position.z - 10),
            new Vector3 (upleft2object.x - transform.position.x -10, upleft2object.y - transform.position.y +10, upleft2object.z - transform.position.z - 10),
            new Vector3 (upleft3object.x - transform.position.x -10, upleft3object.y - transform.position.y +10, upleft3object.z - transform.position.z - 10),
            new Vector3 (upleft4object.x - transform.position.x -10, upleft4object.y - transform.position.y +10, upleft4object.z - transform.position.z - 10),
            new Vector3 (upleft5object.x - transform.position.x -10, upleft5object.y - transform.position.y +10, upleft5object.z - transform.position.z - 10),
            new Vector3 (upleft6object.x - transform.position.x -10, upleft6object.y - transform.position.y +10, upleft6object.z - transform.position.z - 10),
            new Vector3 (upleft7object.x - transform.position.x -10, upleft7object.y - transform.position.y +10, upleft7object.z - transform.position.z - 10),

            new Vector3 (leftdown1object.x - transform.position.x -10, leftdown1object.y - transform.position.y -10, leftdown1object.z - transform.position.z - 10),
            new Vector3 (leftdown2object.x - transform.position.x -10, leftdown2object.y - transform.position.y -10, leftdown2object.z - transform.position.z - 10),
            new Vector3 (leftdown3object.x - transform.position.x -10, leftdown3object.y - transform.position.y -10, leftdown3object.z - transform.position.z - 10),
            new Vector3 (leftdown4object.x - transform.position.x -10, leftdown4object.y - transform.position.y -10, leftdown4object.z - transform.position.z - 10),
            new Vector3 (leftdown5object.x - transform.position.x -10, leftdown5object.y - transform.position.y -10, leftdown5object.z - transform.position.z - 10),
            new Vector3 (leftdown6object.x - transform.position.x -10, leftdown6object.y - transform.position.y -10, leftdown6object.z - transform.position.z - 10),
            new Vector3 (leftdown7object.x - transform.position.x -10, leftdown7object.y - transform.position.y -10, leftdown7object.z - transform.position.z - 10),

            new Vector3 (downright1object.x - transform.position.x +10, downright1object.y - transform.position.y -10, downright1object.z - transform.position.z - 10),
            new Vector3 (downright2object.x - transform.position.x +10, downright2object.y - transform.position.y -10, downright2object.z - transform.position.z - 10),
            new Vector3 (downright3object.x - transform.position.x +10, downright3object.y - transform.position.y -10, downright3object.z - transform.position.z - 10),
            new Vector3 (downright4object.x - transform.position.x +10, downright4object.y - transform.position.y -10, downright4object.z - transform.position.z - 10),
            new Vector3 (downright5object.x - transform.position.x +10, downright5object.y - transform.position.y -10, downright5object.z - transform.position.z - 10),
            new Vector3 (downright6object.x - transform.position.x +10, downright6object.y - transform.position.y -10, downright6object.z - transform.position.z - 10),
            new Vector3 (downright7object.x - transform.position.x +10, downright7object.y - transform.position.y -10, downright7object.z - transform.position.z - 10),

            new Vector3 (rightup1object.x - transform.position.x +10, rightup1object.y - transform.position.y +10, rightup1object.z - transform.position.z - 10),
            new Vector3 (rightup2object.x - transform.position.x +10, rightup2object.y - transform.position.y +10, rightup2object.z - transform.position.z - 10),
            new Vector3 (rightup3object.x - transform.position.x +10, rightup3object.y - transform.position.y +10, rightup3object.z - transform.position.z - 10),
            new Vector3 (rightup4object.x - transform.position.x +10, rightup4object.y - transform.position.y +10, rightup4object.z - transform.position.z - 10),
            new Vector3 (rightup5object.x - transform.position.x +10, rightup5object.y - transform.position.y +10, rightup5object.z - transform.position.z - 10),
            new Vector3 (rightup6object.x - transform.position.x +10, rightup6object.y - transform.position.y +10, rightup6object.z - transform.position.z - 10),
            new Vector3 (rightup7object.x - transform.position.x +10, rightup7object.y - transform.position.y +10, rightup7object.z - transform.position.z - 10),

            //bottom
            new Vector3 (upleft1object.x - transform.position.x, upleft1object.y - transform.position.y, upleft1object.z - transform.position.z),
            new Vector3 (upleft2object.x - transform.position.x, upleft2object.y - transform.position.y, upleft2object.z - transform.position.z),
            new Vector3 (upleft3object.x - transform.position.x, upleft3object.y - transform.position.y, upleft3object.z - transform.position.z),
            new Vector3 (upleft4object.x - transform.position.x, upleft4object.y - transform.position.y, upleft4object.z - transform.position.z),
            new Vector3 (upleft5object.x - transform.position.x, upleft5object.y - transform.position.y, upleft5object.z - transform.position.z),
            new Vector3 (upleft6object.x - transform.position.x, upleft6object.y - transform.position.y, upleft6object.z - transform.position.z),
            new Vector3 (upleft7object.x - transform.position.x, upleft7object.y - transform.position.y, upleft7object.z - transform.position.z),

            new Vector3 (leftdown1object.x - transform.position.x, leftdown1object.y - transform.position.y, leftdown1object.z - transform.position.z),
            new Vector3 (leftdown2object.x - transform.position.x, leftdown2object.y - transform.position.y, leftdown2object.z - transform.position.z),
            new Vector3 (leftdown3object.x - transform.position.x, leftdown3object.y - transform.position.y, leftdown3object.z - transform.position.z),
            new Vector3 (leftdown4object.x - transform.position.x, leftdown4object.y - transform.position.y, leftdown4object.z - transform.position.z),
            new Vector3 (leftdown5object.x - transform.position.x, leftdown5object.y - transform.position.y, leftdown5object.z - transform.position.z),
            new Vector3 (leftdown6object.x - transform.position.x, leftdown6object.y - transform.position.y, leftdown6object.z - transform.position.z),
            new Vector3 (leftdown7object.x - transform.position.x, leftdown7object.y - transform.position.y, leftdown7object.z - transform.position.z),

            new Vector3 (downright1object.x - transform.position.x, downright1object.y - transform.position.y, downright1object.z - transform.position.z),
            new Vector3 (downright2object.x - transform.position.x, downright2object.y - transform.position.y, downright2object.z - transform.position.z),
            new Vector3 (downright3object.x - transform.position.x, downright3object.y - transform.position.y, downright3object.z - transform.position.z),
            new Vector3 (downright4object.x - transform.position.x, downright4object.y - transform.position.y, downright4object.z - transform.position.z),
            new Vector3 (downright5object.x - transform.position.x, downright5object.y - transform.position.y, downright5object.z - transform.position.z),
            new Vector3 (downright6object.x - transform.position.x, downright6object.y - transform.position.y, downright6object.z - transform.position.z),
            new Vector3 (downright7object.x - transform.position.x, downright7object.y - transform.position.y, downright7object.z - transform.position.z),

            new Vector3 (rightup1object.x - transform.position.x, rightup1object.y - transform.position.y, rightup1object.z - transform.position.z),
            new Vector3 (rightup2object.x - transform.position.x, rightup2object.y - transform.position.y, rightup2object.z - transform.position.z),
            new Vector3 (rightup3object.x - transform.position.x, rightup3object.y - transform.position.y, rightup3object.z - transform.position.z),
            new Vector3 (rightup4object.x - transform.position.x, rightup4object.y - transform.position.y, rightup4object.z - transform.position.z),
            new Vector3 (rightup5object.x - transform.position.x, rightup5object.y - transform.position.y, rightup5object.z - transform.position.z),
            new Vector3 (rightup6object.x - transform.position.x, rightup6object.y - transform.position.y, rightup6object.z - transform.position.z),
            new Vector3 (rightup7object.x - transform.position.x, rightup7object.y - transform.position.y, rightup7object.z - transform.position.z),
        };

        //     triangles
        int[] tri = new int[168];
        //start between upleft1 and upleft2
        tri[0] = 0;
        tri[1] = 29;
        tri[2] = 1;
        tri[3] = 0;
        tri[4] = 28;
        tri[5] = 29;

        tri[6] = tri[0] + 1;
        tri[7] = tri[1] + 1;
        tri[8] = tri[2] + 1;
        tri[9] = tri[3] + 1;
        tri[10] = tri[4] + 1;
        tri[11] = tri[5] + 1;

        tri[12] = tri[0] + 2;
        tri[13] = tri[1] + 2;
        tri[14] = tri[2] + 2;
        tri[15] = tri[3] + 2;
        tri[16] = tri[4] + 2;
        tri[17] = tri[5] + 2;

        tri[18] = tri[0] + 3;
        tri[19] = tri[1] + 3;
        tri[20] = tri[2] + 3;
        tri[21] = tri[3] + 3;
        tri[22] = tri[4] + 3;
        tri[23] = tri[5] + 3;

        tri[24] = tri[0] + 4;
        tri[25] = tri[1] + 4;
        tri[26] = tri[2] + 4;
        tri[27] = tri[3] + 4;
        tri[28] = tri[4] + 4;
        tri[29] = tri[5] + 4;

        tri[30] = tri[0] + 5;
        tri[31] = tri[1] + 5;
        tri[32] = tri[2] + 5;
        tri[33] = tri[3] + 5;
        tri[34] = tri[4] + 5;
        tri[35] = tri[5] + 5;

        tri[36] = tri[0] + 6;
        tri[37] = tri[1] + 6;
        tri[38] = tri[2] + 6;
        tri[39] = tri[3] + 6;
        tri[40] = tri[4] + 6;
        tri[41] = tri[5] + 6;

        tri[42] = tri[0] + 7;
        tri[43] = tri[1] + 7;
        tri[44] = tri[2] + 7;
        tri[45] = tri[3] + 7;
        tri[46] = tri[4] + 7;
        tri[47] = tri[5] + 7;

        tri[48] = tri[0] + 8;
        tri[49] = tri[1] + 8;
        tri[50] = tri[2] + 8;
        tri[51] = tri[3] + 8;
        tri[52] = tri[4] + 8;
        tri[53] = tri[5] + 8;

        tri[54] = tri[0] + 9;
        tri[55] = tri[1] + 9;
        tri[56] = tri[2] + 9;
        tri[57] = tri[3] + 9;
        tri[58] = tri[4] + 9;
        tri[59] = tri[5] + 9;
    
        tri[60] = tri[0] + 10;
        tri[61] = tri[1] + 10;
        tri[62] = tri[2] + 10;
        tri[63] = tri[3] + 10;
        tri[64] = tri[4] + 10;
        tri[65] = tri[5] + 10;

        tri[66] = tri[0] + 11;
        tri[67] = tri[1] + 11;
        tri[68] = tri[2] + 11;
        tri[69] = tri[3] + 11;
        tri[70] = tri[4] + 11;
        tri[71] = tri[5] + 11;

        tri[72] = tri[0] + 12;
        tri[73] = tri[1] + 12;
        tri[74] = tri[2] + 12;
        tri[75] = tri[3] + 12;
        tri[76] = tri[4] + 12;
        tri[77] = tri[5] + 12;

        tri[78] = tri[0] + 13;
        tri[79] = tri[1] + 13;
        tri[80] = tri[2] + 13;
        tri[81] = tri[3] + 13;
        tri[82] = tri[4] + 13;
        tri[83] = tri[5] + 13;

        tri[84] = tri[0] + 14;
        tri[85] = tri[1] + 14;
        tri[86] = tri[2] + 14;
        tri[87] = tri[3] + 14;
        tri[88] = tri[4] + 14;
        tri[89] = tri[5] + 14;

        tri[90] = tri[0] + 15;
        tri[91] = tri[1] + 15;
        tri[92] = tri[2] + 15;
        tri[93] = tri[3] + 15;
        tri[94] = tri[4] + 15;
        tri[95] = tri[5] + 15;

        tri[96] = tri[0] + 16;
        tri[97] = tri[1] + 16;
        tri[98] = tri[2] + 16;
        tri[99] = tri[3] + 16;
        tri[100] = tri[4] + 16;
        tri[101] = tri[5] + 16;

        tri[102] = tri[0] + 17;
        tri[103] = tri[1] + 17;
        tri[104] = tri[2] + 17;
        tri[105] = tri[3] + 17;
        tri[106] = tri[4] + 17;
        tri[107] = tri[5] + 17;

        tri[108] = tri[0] + 18;
        tri[109] = tri[1] + 18;
        tri[110] = tri[2] + 18;
        tri[111] = tri[3] + 18;
        tri[112] = tri[4] + 18;
        tri[113] = tri[5] + 18;

        tri[114] = tri[0] + 19;
        tri[115] = tri[1] + 19;
        tri[116] = tri[2] + 19;
        tri[117] = tri[3] + 19;
        tri[118] = tri[4] + 19;
        tri[119] = tri[5] + 19;

        tri[120] = tri[0] + 20;
        tri[121] = tri[1] + 20;
        tri[122] = tri[2] + 20;
        tri[123] = tri[3] + 20;
        tri[124] = tri[4] + 20;
        tri[125] = tri[5] + 20;

        tri[126] = tri[0] + 21;
        tri[127] = tri[1] + 21;
        tri[128] = tri[2] + 21;
        tri[129] = tri[3] + 21;
        tri[130] = tri[4] + 21;
        tri[131] = tri[5] + 21;

        tri[132] = tri[0] + 22;
        tri[133] = tri[1] + 22;
        tri[134] = tri[2] + 22;
        tri[135] = tri[3] + 22;
        tri[136] = tri[4] + 22;
        tri[137] = tri[5] + 22;

        tri[138] = tri[0] + 23;
        tri[139] = tri[1] + 23;
        tri[140] = tri[2] + 23;
        tri[141] = tri[3] + 23;
        tri[142] = tri[4] + 23;
        tri[143] = tri[5] + 23;

        tri[144] = tri[0] + 24;
        tri[145] = tri[1] + 24;
        tri[146] = tri[2] + 24;
        tri[147] = tri[3] + 24;
        tri[148] = tri[4] + 24;
        tri[149] = tri[5] + 24;

        tri[150] = tri[0] + 25;
        tri[151] = tri[1] + 25;
        tri[152] = tri[2] + 25;
        tri[153] = tri[3] + 25;
        tri[154] = tri[4] + 25;
        tri[155] = tri[5] + 25;

        tri[156] = tri[0] + 26;
        tri[157] = tri[1] + 26;
        tri[158] = tri[2] + 26;
        tri[159] = tri[3] + 26;
        tri[160] = tri[4] + 26;
        tri[161] = tri[5] + 26;

        tri[162] = tri[0] + 27;
        tri[163] = 28;
        tri[164] = 0;
        tri[165] = tri[3] + 27;
        tri[166] = tri[4] + 27;
        tri[167] = 28;

    //Normals


        //UV's

        //
        fieldofview.vertices = verticies;
        fieldofview.triangles = tri;
    }
}
