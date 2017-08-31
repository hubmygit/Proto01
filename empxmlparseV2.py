import xml.etree.ElementTree as ET

gdict_var={}

def anyxmlparser(gdict):

    fn=raw_input('FileName :')
    if fn=='':
        fn='emp4.xml'

    #gdict={}

    #tree = ET.parse('emp4.xml')
    tree = ET.parse(fn)
    root = tree.getroot()

    for child in root:
        print child.tag,child.text
        for child1 in child:
            print 1,
            print child.tag, child1.tag, child1.text
            gdict[child1.tag]= child1.text
            for child2 in child1:
                print 2,
                print child.tag,child1.tag,child2.tag, child2.text
                gdict[child2.tag]= child2.text
                for child3 in child2:
                    print 3,
                    print child.tag,child1.tag,child2.tag, child3.tag, child3.text
                    gdict[child3.tag]= child3.text
                    for child4 in child3:
                        print 4,
                        print root.tag,child.tag,child1.tag,child2.tag, child3.tag, child4.tag, child4.text
                        gdict[child4.tag]= child4.text
                        for child5 in child4:
                            print 5,
                            print root.tag,child.tag,child1.tag,child2.tag, child3.tag, child4.tag, child5.tag, child5.text
                            gdict[child5.tag]= child5.text
                            for child6 in child5:
                                print 6,
                                print root.tag,child.tag,child1.tag,child2.tag, child3.tag, child4.tag, child5.tag, child6.tag, child6.text
                                gdict[child6.tag]= child6.text


    for x in gdict.items():
    	print x
    raw_input()


if __name__ == '__main__':
    anyxmlparser(gdict_var)




