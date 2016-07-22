#!./mruby
# coding: utf8

w = 320
h = 240

tmpfile = 'tmp.dat'

class Array
  def x; self[0] end; def x=(val); self[0]=val end
  def y; self[1] end; def y=(val); self[1]=val end
end

File.open(tmpfile, "w") do |f|

  def f.line(sp, tp)
    self.write "#{sp.x}\t#{sp.y}\n"
    self.write "#{tp.x}\t#{tp.y}\n"
  end

  f.line [0, h / 2], [w, h / 2]

  prev = [0, 0]

  (0..w).each do |x|
    if x % 4 != 0
      next
    end
    xang = x * Math::PI / 64
    y = Math.sin(xang) * 64
    if x > 0
      f.line [prev.x, prev.y + h / 2], [x, y + h / 2]
    end 
    prev = [x, y]
  end

end

`fwfw.exe drawer --width=#{w} --height=#{h} --title=fwfwgraph --bgcolor=darkgreen --fgcolor=white < #{tmpfile}`

File.delete tmpfile

